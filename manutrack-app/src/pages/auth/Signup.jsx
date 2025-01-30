import React from "react";
import { useState } from "react";
import { Button } from "@/components/ui/button";
import { Card, CardContent } from "@/components/ui/card";
import { Input } from "@/components/ui/input";
import { Checkbox } from "@/components/ui/checkbox";
import { Label } from "@radix-ui/react-label";
import { UserCircle, Eye, EyeOff, Facebook } from "lucide-react";
import { Link } from "react-router-dom";
import { useForm } from "react-hook-form";
import { zodResolver } from "@hookform/resolvers/zod";
import { z } from "zod";
import { Form, FormControl, FormField, FormItem, FormLabel, FormMessage } from "@/components/ui/form";

const schema = z.object({
    name: z.string().min(2, "Name must be at least 2 characters"),
    email: z.string().email("Invalid email address"),
    pwd: z.string().min(8, "Password must be at least 8 characters")
        .regex(/[a-z]/, "Password must contain at least one lowercase letter")
        .regex(/[A-Z]/, "Password must contain at least one uppercase letter")
        .regex(/[0-9]/, "Password must contain at least one number")
        .regex(/[^a-zA-Z0-9]/, "Password must contain at least one special character"),
    pwd_confirm: z.string(),
    agreeterms: z.literal(true, {
        errorMap: () => ({ message: "You must agree to the terms" })
    })
}).refine((data) => data.pwd === data.pwd_confirm, {
    message: "Passwords must match",
    path: ["pwd_confirm"],
});

function SignUp() {
    const [showPassword, setShowPassword] = useState(false);
    const [showConfirmPassword, setShowConfirmPassword] = useState(false);
    const form = useForm({
        resolver: zodResolver(schema),
        defaultValues: {
            name: "",
            email: "",
            pwd: "",
            pwd_confirm: "",
            agreeterms: false
        }
    });

    const onSubmit = (data) => {
        console.log("Form Data:", data);
    };

    return (
        <div className="flex min-h-screen items-center justify-center bg-gray-100">
            <div className="w-[520px]">
                <div className="flex justify-between">
                    <a href="/" className="block text-center">
                        <img src="https://www.okler.net/previews/porto-admin/4.3.0/img/logo-default.png" alt="Porto Admin" className="h-16 mx-auto" />
                    </a>
                    <div className="flex items-center text-sm font-bold bg-[#0088CC] text-white p-2 rounded-sm rounded-b-none">
                        <UserCircle className="mr-2 text-sm text-center" />Sign Up
                    </div>
                </div>
                <Card className="rounded-none border-t-4 border-t-[#0088CC]">
                    <div className="pt-6">
                        <CardContent>
                            <Form {...form}>
                                <form onSubmit={form.handleSubmit(onSubmit)} className="space-y-4">
                                    {/* Name Field */}
                                    <FormField
                                        control={form.control}
                                        name="name"
                                        render={({ field }) => (
                                            <FormItem>
                                                <FormLabel className="block text-sm font-medium mb-1 text-[#84847B]">Name</FormLabel>
                                                <FormControl>
                                                    <Input {...field} placeholder="Your Name" />
                                                </FormControl>
                                                <FormMessage />
                                            </FormItem>
                                        )}
                                    />

                                    {/* Email Field */}
                                    <FormField
                                        control={form.control}
                                        name="email"
                                        render={({ field }) => (
                                            <FormItem>
                                                <FormLabel className="block text-sm font-medium mb-1 text-[#84847B]">E-mail Address</FormLabel>
                                                <FormControl>
                                                    <Input {...field} placeholder="Your Email" />
                                                </FormControl>
                                                <FormMessage />
                                            </FormItem>
                                        )}
                                    />

                                    {/* Password Fields */}
                                    <div className="grid grid-cols-1 sm:grid-cols-2 gap-4">
                                        {/* Password */}
                                        <FormField
                                            control={form.control}
                                            name="pwd"
                                            render={({ field }) => (
                                                <FormItem>
                                                    <FormLabel className="block text-sm font-medium mb-1 text-[#84847B]">Password</FormLabel>
                                                    <FormControl>
                                                        <div className="relative">
                                                            <Input
                                                                {...field}
                                                                type={showPassword ? "text" : "password"}
                                                                placeholder="Password"
                                                                className="pr-10"
                                                            />
                                                            <button
                                                                type="button"
                                                                onClick={() => setShowPassword(!showPassword)}
                                                                className="absolute right-2 top-2.5"
                                                            >
                                                                {showPassword ? (
                                                                    <EyeOff className="h-5 w-5 text-gray-400" />
                                                                ) : (
                                                                    <Eye className="h-5 w-5 text-gray-400" />
                                                                )}
                                                            </button>
                                                        </div>
                                                    </FormControl>
                                                    <FormMessage />
                                                </FormItem>
                                            )}
                                        />

                                        {/* Confirm Password */}
                                        <FormField
                                            control={form.control}
                                            name="pwd_confirm"
                                            render={({ field }) => (
                                                <FormItem>
                                                    <FormLabel className="block text-sm font-medium mb-1 text-[#84847B]">Confirm Password</FormLabel>
                                                    <FormControl>
                                                        <div className="relative">
                                                            <Input
                                                                {...field}
                                                                type={showConfirmPassword ? "text" : "password"}
                                                                placeholder="Confirm Password"
                                                                className="pr-10"
                                                            />
                                                            <button
                                                                type="button"
                                                                onClick={() => setShowConfirmPassword(!showConfirmPassword)}
                                                                className="absolute right-2 top-2.5"
                                                            >
                                                                {showConfirmPassword ? (
                                                                    <EyeOff className="h-5 w-5 text-gray-400" />
                                                                ) : (
                                                                    <Eye className="h-5 w-5 text-gray-400" />
                                                                )}
                                                            </button>
                                                        </div>
                                                    </FormControl>
                                                    <FormMessage />
                                                </FormItem>
                                            )}
                                        />
                                    </div>

                                    {/* Terms Agreement */}
                                    <FormField
                                        control={form.control}
                                        name="agreeterms"
                                        render={({ field }) => (
                                            <FormItem>
                                                <div className="flex items-center">
                                                    <FormControl>
                                                        <Checkbox
                                                            checked={field.value}
                                                            onCheckedChange={field.onChange}
                                                            className="bg-white data-[state=checked]:bg-[transparent] data-[state=checked]:text-black border-gray-300"
                                                        />
                                                    </FormControl>
                                                    <Label className="text-sm ml-1">
                                                        I agree with <a href="#" className="text-blue-500 hover:underline">terms of use</a>
                                                    </Label>
                                                    <div className="ml-auto">
                                                        <Button type="submit" className="bg-[#0088CC] hover:bg-[#00a1f2]">
                                                            Sign Up
                                                        </Button>
                                                    </div>
                                                </div>
                                                <FormMessage />
                                            </FormItem>
                                        )}
                                    />
                                </form>
                            </Form>

                            {/* Social Login Section */}
                            <div className="my-6 text-center relative">
                                <span className="bg-white px-2 text-sm text-gray-500">OR</span>
                                <div className="absolute inset-x-0 top-1/2 border-t border-gray-300" />
                            </div>

                            <div className="flex items-center justify-center text-center">
                                <Button variant="outline" className="w-1/2 flex items-center justify-center bg-[#4162a7] text-white hover:bg-[#486fc4] hover:text-white">
                                    Connect with <Facebook className="ml-2" />
                                </Button>
                            </div>

                            <p className="mt-4 text-center text-sm">
                                Already have an account?{" "}
                                <Link to="/sign-in" className="text-blue-500 hover:underline">Sign In!</Link>
                            </p>
                        </CardContent>
                    </div>
                </Card>
                <p className="mt-6 text-center text-sm text-gray-500">&copy; Copyright 2023. All Rights Reserved.</p>
            </div>
        </div>
    );
};

export default SignUp;