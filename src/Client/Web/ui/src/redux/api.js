import axios from "axios";
import JWTHelper from "../utils/jwtHelper";

const API = axios.create({
    baseURL:"https://localhost:44316/api",
    headers:{
        "Content-Type": 'application/json;charset=UTF-8',
        "Access-Control-Allow-Origin": "*"
    }
});

axios.interceptors.request.use(function (config) {
    // Do something before request is sent
    return config;
  }, function (error) {
    // Do something with request error
    return Promise.reject(error);
  });

// Add a response interceptor
axios.interceptors.response.use(function (response) {
    // Do something with response data
    return response;
  }, function (error) {
    // Do something with response error
    return Promise.reject(error);
  });

export const signIn = (formData) => API.post("/auth/login", formData);
export const signUp = (formData) => API.post("/auth/register", formData);
export const getAllPosts = () => API.get('/posts/userPosts');
export const getByIdPost = (id) => API.get(`/posts/${id}`);
export const getByIdUser = (id) => API.get(`/users/${id}`, { headers: {
    "Authorization": `Bearer ${JWTHelper.getToken().token}`
}});
export const getAllUsers = () => {
    const {token} = JWTHelper.getToken();
    if(token != null){
        return API.get(`/users`, {
            headers: {
                "Authorization": `Bearer ${token}`
            }
        });
    }
}

export const updateUser = (formData) => {
    const {token} = JWTHelper.getToken();
    if(token != null){
        return API.put(`/users`, formData, {
            headers: {
                "Authorization": `Bearer ${token}`
            }
        });
    }
};

export const deleteByIdPost = (id) => {
    const {token} = JWTHelper.getToken();
    if(token != null){
        return API.delete(`/posts/${id}`, {
            headers: {
                "Authorization": `Bearer ${token}`
            }
        });
    }
};

export const addPost = (formData) => {
    const profile = JSON.parse(localStorage.getItem('profile'));
    const post = {
        userId: profile.user.id,
        message: formData
    }

    if(profile && profile.token != null){
        return API.post(`/posts`, post,{
            headers: {
                "Authorization": `Bearer ${profile.token}`
            }
        });
    }
}
