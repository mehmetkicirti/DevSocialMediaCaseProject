import {configureStore} from "@reduxjs/toolkit";
import AuthReducer from "./features/authSlice";
import UserReducer from "./features/userSlice";
import PostReducer from "./features/postSlice";

export default configureStore({
    reducer:{
        auth: AuthReducer,
        user: UserReducer,
        post: PostReducer
    },
});
