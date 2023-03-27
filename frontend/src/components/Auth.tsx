import { useState, useEffect } from 'react'
import { useNavigate, Link } from 'react-router-dom'
import { toast } from 'react-toastify'
import 'react-toastify/dist/ReactToastify.css';

import { useAppDispatch } from '../hooks/reduxHook'

import { Box, Button, Typography, Grid, Paper, Avatar, TextField } from '@mui/material'
import { LockOutlined } from '@mui/icons-material'
import { createTheme, ThemeProvider } from '@mui/material/styles';
import CssBaseline from '@mui/material/CssBaseline';

import Header from "./Header"

import { setUser } from '../redux/reducer/authReducer'
import { useLoginUserMutation, useRegisterUserMutation } from '../services/authApi'

import { User } from '../types/Auth'

const Copyright = (props: any) => {
    return (
        <Typography variant="body2" color="text.secondary" align="center" {...props}>
            {'Copyright © '}
            <Link color="inherit" to={'/'} >
                Lu-Lu
            </Link>{' '}
            {new Date().getFullYear()}
            {'.'}
        </Typography>
    );
}
const theme = createTheme();
const initialState = {
    name: "",
    email: "",
    password: "",
    confirmPassword: "",
    avatar: ""
}

const Auth = (props: any) => {
    const navigate = useNavigate()
    const dispatch = useAppDispatch()
    const [formValue, setFormValue] = useState(initialState)
    const { email, password, confirmPassword, name, avatar } = formValue
    const [showRegister, setShowRegister] = useState(false)
    const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
        setFormValue({ ...formValue, [e.target.name]: e.target.value })
    }
    props.selectUser(formValue);
    const [loginUser,
        { data: loginData, isSuccess: isLoginSuccess, isError: isLoginError, error: LoginEror }] = useLoginUserMutation()
    const [registerUser,
        { data: registerData, isSuccess: isRegisterSuccess, isError: isRegisterError, error: RegisterEror }] = useRegisterUserMutation()
    const handleLogin = async () => {
        if (email && password) {
            await loginUser({ email, password })
        }
        else {
            toast.error("Please fill all required fileds!")
        }
    }
    const handleRegister = async () => {
        if (password !== confirmPassword) {
            toast.error("Password do not match")
        }
        else if (!name && !email && !password && !confirmPassword) {
            toast.error("Please fill all required fileds!")
        }
        else {
            const avatar = "https://api.lorem.space/image/face?w=640&h=480"
            if (email && password && name && avatar) {
                await registerUser({ email, password, name, avatar })
            }
        }
    }
    useEffect(() => {
        if (isLoginSuccess) {
            toast.success('User login successfully')
            dispatch(setUser({
                token: loginData
            }))
            navigate("/home")
        }
        if (isRegisterSuccess) {
            toast.success('User register successfully')
            dispatch(setUser({
                token: registerData
            }))
            navigate("/home")
        }
    }, [isLoginSuccess, isRegisterSuccess])
    useEffect(() => {
        if (isLoginError) {
            toast.error((LoginEror as any).data.message)
        }
        if (isRegisterError) {
            toast.error((RegisterEror as any).data.message)
        }
    }, [isLoginError, isRegisterError])

    return (
        <>
            <Header />
            <ThemeProvider theme={theme}>
                <CssBaseline />
                <Grid container component="main" sx={{ height: '100vh' }}>
                    <Grid className='main__grid'
                        item
                        xs={false}
                        sm={4}
                        md={7}
                    />
                    <Grid className='main__grid__login' item xs={12} sm={8} md={5} component={Paper} elevation={6} square>
                        <Box className='main__login'
                            sx={{
                                my: 8,
                                mx: 4,
                                display: 'flex',
                                flexDirection: 'column',
                                alignItems: 'center',
                            }}
                        >
                            <Avatar sx={{ m: 1, bgcolor: 'secondary.main' }}>
                                <LockOutlined />
                            </Avatar>
                            <Typography component="h6" variant="h6">
                                {!showRegister ? "Signin" : "Register"}
                            </Typography>
                            <Typography component="h6" variant="h6">
                                {!showRegister ? "Please enter you email and password" :
                                    "Please enter user detail"}
                            </Typography>
                            <Box component="form" noValidate sx={{ mt: 1 }}>
                                {showRegister && (
                                    <TextField
                                        margin="normal"
                                        type="text"
                                        required
                                        fullWidth
                                        id="name"
                                        label="Type your name"
                                        name="name"
                                        autoFocus
                                        value={name} onChange={handleChange}
                                    />
                                )}
                                <TextField
                                    margin="normal"
                                    type="email"
                                    required
                                    fullWidth
                                    id="email"
                                    label="Type your email"
                                    name="email"
                                    autoFocus
                                    value={email} onChange={handleChange}
                                />
                                <TextField
                                    margin="normal"
                                    required
                                    fullWidth
                                    type="password"
                                    id="password"
                                    label="Type your password"
                                    name="password"
                                    value={password} onChange={handleChange}
                                />
                                {showRegister && (
                                    <TextField
                                        margin="normal"
                                        required
                                        fullWidth
                                        id="name"
                                        type="password"
                                        label="Confirm your password"
                                        name="confirmPassword"
                                        value={confirmPassword} onChange={handleChange}
                                    />
                                )}
                            </Box>
                            {!showRegister ?
                                (<Button type="submit" variant="contained" sx={{ mt: 3, mb: 2 }} onClick={() => handleLogin()}>
                                    Login
                                </Button>) :
                                (<Button type="submit" variant="contained" sx={{ mt: 3, mb: 2 }} onClick={() => handleRegister()}>
                                    Register
                                </Button>)
                            }
                            <Box>
                                <Typography component="h6" variant="h6">
                                    {!showRegister ?
                                        (
                                            <>
                                                Don't have an account ?
                                                <Typography component="h6" variant="h6" style={{ cursor: "pointer", textAlign: "center" }}
                                                    onClick={() => setShowRegister(true)}>
                                                    Sign Up
                                                </Typography>
                                            </>
                                        )
                                        : (
                                            <>
                                                Already have an account ?
                                                <Typography component="h6" variant="h6" style={{ cursor: "pointer", textAlign: "center" }}
                                                    onClick={() => setShowRegister(false)}>
                                                    Signin
                                                </Typography>
                                            </>
                                        )}
                                </Typography>
                                <Copyright sx={{ mt: 5 }} />
                            </Box>
                        </Box>
                    </Grid>
                </Grid>
            </ThemeProvider>
        </>
    )
}
export default Auth