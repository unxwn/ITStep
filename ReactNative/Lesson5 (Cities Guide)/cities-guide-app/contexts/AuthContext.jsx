import { createContext, useEffect, useState } from "react";
import { account } from "../utils/appwrite";
import { ID } from "react-native-appwrite";

export const AuthContext = createContext(null);

const AuthProvider = ({ children }) => {
    const [user, setUser] = useState(null);
    const [authChecked, setAuthChecked] = useState(false);
    const [loading, setLoading] = useState(false);

    // Перевіряємо сесію при старті
    async function getAuthCheckedStatus() {
        try {
            const resp = await account.get();
            setUser(resp);
        } catch (err) {
            console.log("Appwrite account.get error:", err); // виведи весь об'єкт помилки
        } finally {
            setAuthChecked(true);
        }
    }

    useEffect(() => {
        getAuthCheckedStatus();
    }, []);

    const register = async (email, password) => {
        setLoading(true);
        try {
            await account.create({
                userId: ID.unique(),
                email,
                password,
            });

            await login(email, password);
        } catch (error) {
            throw new Error(error.message || "Registration failed");
        } finally {
            setLoading(false);
        }
    };

    const login = async (email, password) => {
        setLoading(true);
        try {
            await account.createEmailPasswordSession({
                email,
                password,
            });
            const resp = await account.get();
            setUser(resp);
            return resp;
        } catch (error) {
            throw new Error(error.message || "Login failed");
        } finally {
            setLoading(false);
        }
    };

    const logout = async () => {
        setLoading(true);
        try {
            await account.deleteSession({ sessionId: "current" });
            setUser(null);
        } catch (error) {
            console.log("Logout error:", error.message);
        } finally {
            setLoading(false);
        }
    };

    return (
        <AuthContext.Provider
            value={{ user, register, login, logout, authChecked, loading }}
        >
            {children}
        </AuthContext.Provider>
    );
};

export default AuthProvider;
