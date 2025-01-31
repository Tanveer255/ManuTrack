import { BrowserRouter, Navigate, Route, Routes } from "react-router-dom";
import Dashboard from "./pages/dashboard/page";
import Notfound from "./pages/Notfound/Notfound";
import { AppSidebar } from "./components/ui/app-sidebar";
import { useEffect, useState } from "react";
import Login from "./pages/Login/Login";
import { Toaster } from "react-hot-toast";
import { SidebarProvider } from "./components/ui/sidebar";
import SignUp from "./pages/SignUp/SignUp";
import Acount from "./pages/Acount/Acount";

function App() {
    const [isLoggedIn, setIsLoggedIn] = useState(true);

    useEffect(() => {
      const token = localStorage.getItem("token");
      setIsLoggedIn(!!token);
    }, []);

    const handleLogin = () => {
        setIsLoggedIn(true);
    };

    const handleLogout = () => {
        localStorage.removeItem("token");
        setIsLoggedIn(false);
    };

    return (
        <>
            <BrowserRouter>
                {isLoggedIn ? (
                    <SidebarProvider>
                        <AppSidebar handleLogout={handleLogout} />
                        <Routes>
                            <Route path="/" element={<Dashboard />} />
                            <Route path="/account" element={<Acount />} />
                            <Route path="*" element={<Notfound />} />
                        </Routes>
                    </SidebarProvider>
                ) : (
                    <Routes>
                        <Route
                            path="/login"
                            element={<Login handleLogin={handleLogin} />}
                        />
                        <Route path="/sign-up" element={<SignUp />} />
                        <Route path="*" element={<Navigate to="/login" />} />
                    </Routes>
                )}
                <Toaster position="bottom-right" />
            </BrowserRouter>
        </>
    );
}

export default App;
