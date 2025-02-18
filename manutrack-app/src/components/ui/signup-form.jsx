import { useForm } from "react-hook-form";
import { useNavigate } from "react-router-dom";
import axios from "axios";
import { toast } from "react-toastify";
import { GalleryVerticalEnd } from "lucide-react";
import { cn } from "@/lib/utils";
import { Button } from "@/components/ui/button";
import { Input } from "@/components/ui/input";
import { Label } from "@/components/ui/label";

export function SignUpForm({ className, ...props }) {
    const {
        register,
        handleSubmit,
        reset,
        formState: { errors },
    } = useForm();

    const navigate = useNavigate();

    const SignupUser = (data) => {
        const requestData = {
            firstName: data.firstName,
            lastName: data.lastName,
            email: data.email,
            usernameChangeLimit: 0,
            profilePicture: null,
            userName: data.userName,
            password: data.password,
            phoneNumber: data.phoneNumber,
            phoneNumberConfirmed: true,
        };

        axios
            .post("https://localhost:7067/users/signup", requestData)
            .then((res) => {
                toast.success("User signed up successfully");
                navigate("/");
                reset();
            })
            .catch((err) => {
                const errorMessage = err.response?.data?.message || "Signup failed. Please try again.";
                toast.error(errorMessage);
            });
    };

    return (
        <div className={cn("flex flex-col gap-6", className)} {...props}>
            <form onSubmit={handleSubmit(SignupUser)}>
                <div className="flex flex-col gap-6">
                    <div className="flex flex-col items-center gap-2">
                        <GalleryVerticalEnd className="size-6" />
                        <h1 className="text-xl font-bold">Sign Up</h1>
                    </div>
                    <div className="grid gap-2">
                        <Label htmlFor="firstName">First Name</Label>
                        <Input id="firstName" {...register("firstName", { required: "First name is required" })} />
                        {errors.firstName && <span className="text-red-500 text-sm">{errors.firstName.message}</span>}
                    </div>
                    <div className="grid gap-2">
                        <Label htmlFor="lastName">Last Name</Label>
                        <Input id="lastName" {...register("lastName", { required: "Last name is required" })} />
                        {errors.lastName && <span className="text-red-500 text-sm">{errors.lastName.message}</span>}
                    </div>
                    <div className="grid gap-2">
                        <Label htmlFor="email">Email</Label>
                        <Input id="email" type="email" {...register("email", { required: "Email is required" })} />
                        {errors.email && <span className="text-red-500 text-sm">{errors.email.message}</span>}
                    </div>
                    <div className="grid gap-2">
                        <Label htmlFor="userName">Username</Label>
                        <Input id="userName" {...register("userName", { required: "Username is required" })} />
                        {errors.userName && <span className="text-red-500 text-sm">{errors.userName.message}</span>}
                    </div>
                    <div className="grid gap-2">
                        <Label htmlFor="password">Password</Label>
                        <Input id="password" type="password" {...register("password", { required: "Password is required" })} />
                        {errors.password && <span className="text-red-500 text-sm">{errors.password.message}</span>}
                    </div>
                    <div className="grid gap-2">
                        <Label htmlFor="phoneNumber">Phone Number</Label>
                        <Input id="phoneNumber" {...register("phoneNumber", { required: "Phone number is required" })} />
                        {errors.phoneNumber && <span className="text-red-500 text-sm">{errors.phoneNumber.message}</span>}
                    </div>
                    <Button type="submit" className="w-full">Sign Up</Button>
                </div>
            </form>
        </div>
    );
}
