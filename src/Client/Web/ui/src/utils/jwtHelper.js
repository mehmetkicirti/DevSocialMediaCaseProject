
class JWTHelper{
    static getUserDetails(){
        const profile = JSON.parse(localStorage.getItem("profile"));
        if(profile && profile.user){
            return {
                user: profile.user
            };
        }
        return {user:null};
    }

    static logout(){
        return localStorage.removeItem("profile");
    }

    static getToken(){
        const profile = JSON.parse(localStorage.getItem("profile"));
        return profile && profile.token && {
            token: profile.token
        };
    }
}


export default JWTHelper;
