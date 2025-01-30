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
import { Link, useNavigate } from "react-router-dom";
import toast from "react-hot-toast";

export function LoginForm({ className, handleLogin, ...props }) {
  let {
    register,
    handleSubmit,
    reset,
    formState: { errors },
  } = useForm();

  let navigate = useNavigate();

  const loginUser = (data) => {
    axios
      .post("/Users/login", data)
      .then((res) => {
        toast.success("User Login successfully");
        localStorage.setItem("token", res.data.token.result);
        navigate("/");
        handleLogin();
        reset();
      })
      .catch((err) => {
        toast.error(err.response);
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
              <div className="grid gap-2">
                <Label htmlFor="email">Email</Label>
                <Input
                  type="text"
                  placeholder="John"
                  {...register("Username", { required: true })}
                  className={`${
                    errors.Username ? "bg-red-500 bg-opacity-50" : ""
                  }`}
                  required
                />
              </div>
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
                  {...register("Password", { required: true })}
                  className={`${
                    errors.Password ? "bg-red-500 bg-opacity-50" : ""
                  }`}
                  required
                />
              </div>
              <Button type="submit" className="w-full">
                Login
              </Button>
              <Button variant="outline" className="w-full">
                Login with Google
              </Button>
            </div>
            <div className="mt-4 text-center text-sm">
              Don&apos;t have an account?{" "}
              <a href="/sign-up" className="underline underline-offset-4">
                Sign up
              </a>
            </div>
          </form>
        </CardContent>
      </Card>
    </div>
  );
}
