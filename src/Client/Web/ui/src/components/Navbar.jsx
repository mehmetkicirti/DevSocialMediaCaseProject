import ConnectWithoutContactIcon from '@mui/icons-material/ConnectWithoutContact';
import {Link} from "react-router-dom";
import { createBrowserHistory } from "history"
import {
  AppBar,
  Avatar,
  Button,
  Box,
  Menu,
  MenuItem,
  styled,
  Toolbar,
  Typography,
  MenuList,
  ButtonGroup
} from "@mui/material";
import React, { useState } from "react";
import JWTHelper from '../utils/jwtHelper';
import { toast } from 'react-toastify';

const StyledToolbar = styled(Toolbar)({
  display: "flex",
  justifyContent: "space-between",
});

const Search = styled("div")(({ theme }) => ({
  backgroundColor: "white",
  padding: "0 10px",
  borderRadius: theme.shape.borderRadius,
  width: "40%",
}));

const Icons = styled(Box)(({ theme }) => ({
  display: "none",
  alignItems: "center",
  gap: "20px",
  [theme.breakpoints.up("sm")]: {
    display: "flex",
  },
}));

const UserBox = styled(Box)(({ theme }) => ({
  display: "flex",
  alignItems: "center",
  gap: "10px",
  [theme.breakpoints.up("sm")]: {
    display: "none",
  },
}));

export const getButton = (user, color, to, text) => (
  user != null ? <></> : <Button component={Link} sx={{ display: { xs: "none", sm: "block" } }} to={to} variant="contained" color={color}>
  {text}
</Button>
);

const Navbar = ({user}) => {
  const [open, setOpen] = useState(false);
  const [openSmButton, setSmButton] = useState(false);
  const history = createBrowserHistory();

  const onLogout = () => {
    JWTHelper.logout();
    toast.info("Çıkış yapılıyor.");
    setOpen(false);
    setTimeout(()=>{
      history.push("/");
      history.go();
    },2500);
  }
  return (
    <AppBar color='warning' position="sticky">
      <StyledToolbar sx={{display:"flex"}}>
        <Typography variant="h6" sx={{ display: { xs: "none", sm: "block" } }}>
          Social Media
        </Typography>
        <ConnectWithoutContactIcon onClick={(e) => setSmButton(true)} sx={{ display: { xs: "block", sm: "none" } }} />
        <ButtonGroup>
          {
            getButton(user,"success","/register","Sign Up")
          }
          {
            getButton(user,"secondary","/login","Sign In")
          }
        </ButtonGroup>
        {
          user != null ? 
          <Icons>
          <Avatar
            sx={{ width: 30, height: 30 }}
            src="https://images.pexels.com/photos/846741/pexels-photo-846741.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=2"
            onClick={(e) => setOpen(true)}
          />
        </Icons> : <></>
        }
        {
          user != null ?
          <UserBox onClick={(e) => setOpen(true)}>
            <Avatar
              sx={{ width: 30, height: 30 }}
              src="https://images.pexels.com/photos/846741/pexels-photo-846741.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=2"
            />
            <Typography variant="span">John</Typography>
          </UserBox> : <></>
        }
      </StyledToolbar>
      <Menu
        id="demo-positioned-menu"
        aria-labelledby="demo-positioned-button"
        open={open}
        onClose={(e) => setOpen(false)}
        anchorOrigin={{
          vertical: "top",
          horizontal: "right",
        }}
        transformOrigin={{
          vertical: "top",
          horizontal: "right",
        }}
      >
        <Link onClick={e => setOpen(false)} to="/profile" style={{ textDecoration: 'none', display: 'block', color:"black" }}>
          <MenuItem>Profile</MenuItem>
        </Link>
        <MenuItem onClick={onLogout}>Logout</MenuItem>
      </Menu>
      <Menu
        sx={{ display: { xs: "block", sm: "none" } }}
        id="demo-positioned-menu"
        aria-labelledby="demo-positioned-button"
        open={user == null ? openSmButton : false}
        onClose={(e) => setSmButton(false)}
        anchorOrigin={{
          vertical: "top",
          horizontal: "left",
        }}
        transformOrigin={{
          vertical: "top",
          horizontal: "left",
        }}
      >
        <MenuList>
          <Link to="/login" style={{ textDecoration: 'none', display: 'block', color:"black" }}>
            <MenuItem>Login</MenuItem>
          </Link>
          <Link to="/register" style={{ textDecoration: 'none', display: 'block', color:"black" }}>
            <MenuItem>Register</MenuItem>
          </Link>
        </MenuList>
      </Menu>
    </AppBar>
  );
};

export default Navbar;