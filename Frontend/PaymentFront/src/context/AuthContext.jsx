import { createContext, useState, useEffect } from "react";

const AuthContext = createContext(null);

export function AuthProvider({ children }) {
  const [token, setToken] = useState(() => localStorage.getItem("token"));
  const [email, setEmail] = useState(() => localStorage.getItem("email"));

  useEffect(() => {
    if (token) {
      localStorage.setItem("token", token);
    } else {
      localStorage.removeItem("token");
    }
  }, [token]);

  useEffect(() => {
    if (email) {
      localStorage.setItem("email", email);
    } else {
      localStorage.removeItem("email");
    }
  }, [email]);

  function login(newToken, newEmail) {
    setToken(newToken);
    setEmail(newEmail);
  }

  function logout() {
    setToken(null);
    setEmail(null);
    localStorage.removeItem("token");
    localStorage.removeItem("email");
  }

  return (
    <AuthContext.Provider value={{ token, email, isAuthenticated: !!token, login, logout }}>
      {children}
    </AuthContext.Provider>
  );
}

export { AuthContext };
