import { CircleUser, Facebook, Lock, User, UserCircle } from "lucide-react";

import { Card, CardTitle, CardContent } from "@/components/ui/card";
import { Input } from "@/components/ui/input";
import { Button } from "@/components/ui/button";
import { Checkbox } from "@/components/ui/checkbox";
import { LogoImage } from "@/img";
import { z } from "zod";
import { zodResolver } from "@hookform/resolvers/zod";
import { useForm } from "react-hook-form";

import {
  Form,
  FormControl,
  FormField,
  FormItem,
  FormLabel,
  FormMessage,
} from "@/components/ui/form";
import { Link } from "react-router-dom";

const signInFormSchema = z.object({
  email: z.string().email("Please enter valid email."),
  password: z.string().min(6, {
    message: "Password must be at least 6 characters.",
  }),
});

function SignIn() {
  const form = useForm({
    resolver: zodResolver(signInFormSchema),
  });

  function onSubmit(values) {
    console.log(values);
  }

  return (
    <section className="flex justify-center items-center min-h-screen bg-gray-100">
      <div className="w-[520px] px-4">
        <div className="flex justify-between items-end ">
          <a href="/" className="block text-center ">
            <img src={LogoImage} alt="Porto Admin" className="h-16 mx-auto" />
          </a>
          <h2 className="text-sm bg-porto rounded-tl-md rounded-tr-md p-4 text-white font-bold uppercase flex justify-center items-center gap-2 mb-[-3px] mr-[1px]">
            <CircleUser className=" w-6 h-6" /> Sign In
          </h2>
        </div>
        <Card className="shadow-sm">
          <CardContent className="p-6 border-t-4 rounded-tl-md border-porto">
            <Form {...form}>
              <form
                onSubmit={form.handleSubmit(onSubmit)}
                className="space-y-4"
              >
                <div className="space-y-1">
                  <FormField
                    control={form.control}
                    name="email"
                    render={({ field }) => (
                      <FormItem>
                        <FormLabel>Email</FormLabel>
                        <FormControl>
                          <div className="flex items-center border border-gray-300 rounded-md overflow-hidden">
                            <Input
                              id="username"
                              name="email"
                              placeholder="Enter your username"
                              className="border-none flex-1 focus:outline-none"
                              {...field}
                            />
                            <span className="p-3 bg-gray-100">
                              <User className="text-gray-600 w-5 h-5" />
                            </span>
                          </div>
                        </FormControl>
                        <FormMessage />
                      </FormItem>
                    )}
                  />
                </div>

                <div className="space-y-1">
                  <FormField
                    control={form.control}
                    name="password"
                    render={({ field }) => (
                      <FormItem>
                        <div className="flex justify-between items-center">
                          <FormLabel>Password</FormLabel>
                          <a
                            href="pages-recover-password.html"
                            className="text-sm text-porto hover:underline"
                          >
                            Lost Password?
                          </a>
                        </div>
                        <FormControl>
                          <div className="flex items-center border border-gray-300 rounded-md overflow-hidden">
                            <Input
                              type="password"
                              placeholder="Enter your username"
                              className="border-none flex-1 focus:outline-none"
                              {...field}
                            />
                            <span className="p-3 bg-gray-100">
                              <Lock className="text-gray-600 w-5 h-5" />
                            </span>
                          </div>
                        </FormControl>
                        <FormMessage />
                      </FormItem>
                    )}
                  />
                </div>

                <div className="flex justify-between items-center">
                  <div className="flex items-center gap-2">
                    <Checkbox id="rememberme" name="rememberme" />
                    <label
                      htmlFor="rememberme"
                      className="text-sm text-gray-700"
                    >
                      Remember Me
                    </label>
                  </div>
                  <Button variant="proto" type="submit">
                    Sign In
                  </Button>
                </div>

                <div className="relative py-4">
                  <div className="absolute inset-0 flex items-center">
                    <div className="w-full border-t border-gray-300"></div>
                  </div>
                  <div className="relative flex justify-center text-sm">
                    <span className="bg-white px-2 text-gray-500">or</span>
                  </div>
                </div>

                <div className="text-center">
                  <Button variant="proto" className="w-full">
                    Connect with <Facebook className="inline ml-2" />
                  </Button>
                </div>

                <p className="text-center text-sm text-gray-600">
                  Don&apos;t have an account yet?{" "}
                  <Link
                    to="/sign-up"
                    className="text-porto hover:underline"
                  >
                    Sign Up!
                  </Link>
                </p>
              </form>
            </Form>
          </CardContent>
        </Card>
        <p className="text-center text-sm text-gray-500 mt-4">
          &copy; Copyright 2023. All Rights Reserved.
        </p>
      </div>
    </section>
  );
}

export default SignIn;
