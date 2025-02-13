import { cn } from "@/lib/utils";
import { Button } from "@/components/ui/button";
import {
    Card,
    CardContent,
    CardDescription,
    CardHeader,
    CardTitle,
} from "@/components/ui/card";
import { Input } from "@/components/ui/input";
import { Label } from "@/components/ui/label";
import axios from "axios";
import { useForm } from "react-hook-form";
import { Link, data, useNavigate } from "react-router-dom";
import toast from "react-hot-toast";

export function LoginForm({ className, handleLogin, ...props }) {
    let {
        register,
        handleSubmit,
        reset,
        formState: { errors },
    } = useForm();

    let navigate = useNavigate();
    console.log(data);
    const loginUser = (data) => {
        axios
            .post("https://localhost:7067/auth/Login", data)
            .then((res) => {
                toast.success("User logged in successfully");
                localStorage.setItem("token", res.data.token);
                navigate("/");
                handleLogin();
                reset();
            })
            .catch((err) => {
                const errorMessage = err.response?.data?.message || "Login failed. Please try again.";
                toast.error(errorMessage);
            });
    };
    return (
        <div className={cn("flex flex-col gap-6", className)} {...props}>
            <Card>
                <CardHeader>
                    <CardTitle className="text-2xl">Login</CardTitle>
                    <CardDescription>
                        Enter your email below to login to your account
                    </CardDescription>
                </CardHeader>
                <CardContent>
                    <form onSubmit={handleSubmit(loginUser)}>
                        <div className="flex flex-col gap-6">
                            {/* Username Field */}
                            <div className="grid gap-2">
                                <Label htmlFor="email">Email</Label>
                                <Input
                                    type="text"
                                    id="email"
                                    placeholder="Enter your username"
                                    {...register("email", { required: "Username is required" })}
                                    className={`${errors.email ? "bg-red-500 bg-opacity-50" : ""}`}
                                />
                                {errors.email && <span className="text-red-500 text-sm">{errors.email.message}</span>}
                            </div>

                            {/* Password Field */}
                            <div className="grid gap-2">
                                <div className="flex items-center">
                                    <Label htmlFor="password">Password</Label>
                                    <a
                                        href="#"
                                        className="ml-auto inline-block text-sm underline-offset-4 hover:underline"
                                    >
                                        Forgot your password?
                                    </a>
                                </div>
                                <Input
                                    id="password"
                                    type="password"
                                    placeholder="Enter your password"
                                    {...register("password", { required: "Password is required" })}
                                    className={`${errors.password ? "bg-red-500 bg-opacity-50" : ""}`}
                                />
                                {errors.password && <span className="text-red-500 text-sm">{errors.password.message}</span>}
                            </div>

                            {/* Submit Button */}
                            <Button type="submit" className="w-full">
                                Login
                            </Button>

                            {/* Google Login Button */}
                            <Button variant="outline" className="w-full">
                                Login with Google
                            </Button>
                        </div>

                        <div className="mt-4 text-center text-sm">
                            Don&apos;t have an account?{" "}
                            <Link to="/sign-up" className="underline underline-offset-4">
                                Sign up
                            </Link>
                        </div>
                    </form>
                </CardContent>
            </Card>
        </div>
    );
}
