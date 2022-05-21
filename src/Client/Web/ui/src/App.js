import {BrowserRouter, Routes, Route, Navigate } from "react-router-dom";
import {ToastContainer} from "react-toastify";
import 'react-toastify/dist/ReactToastify.css';
import NotFound from "./components/NotFound";
import MainLayout from "./layouts/MainLayout";
import Home from "./pages/Home";
import Login from "./pages/Login";
import Profile from "./pages/Profile";
import Register from "./pages/Register";
import JWTHelper from "./utils/jwtHelper";
function App() {
  const token = JWTHelper.getToken();
  return (
    <BrowserRouter>
      <div>
        <ToastContainer/>
          <Routes>
            <Route path="/" element={<MainLayout><Home/></MainLayout>} />
            <Route path="/profile" element={token != null ? <MainLayout><Profile/></MainLayout> : <Navigate to="/error"/>} />
            <Route exact path="/login" element={<Login/>} />
            <Route exact path="/register" element={<Register/>} />
            <Route path="/error" element={<NotFound direct errorValue={"You are not authenticated"} isAuthenticated={token == null}/>}/>
          </Routes> 
      </div>
    </BrowserRouter>
  );
}

export default App;
