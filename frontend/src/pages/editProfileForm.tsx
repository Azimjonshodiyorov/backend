import { useAppDispatch } from '../hooks/reduxHook'
import { useState } from 'react'

import { Box, TextField, Button } from '@mui/material'
import { toast } from 'react-toastify'
import 'react-toastify/dist/ReactToastify.css'

import { editUser } from '../redux/reducer/userReducer'

const ProfileForm = (props: any) => {
  const dispatch = useAppDispatch()
  const initialState = {
    name: "",
    email: "",
    password: "",
    confirmPassword: "",
    avatar: ""
  }
  const [formValue, setFormValue] = useState(initialState)
  const { name, email, password, confirmPassword, avatar } = formValue
  const newName = formValue.name
  const newEmail = formValue.email
  const newPassword = formValue.password
  const newConfirmPassword = formValue.confirmPassword
  const handleChange = (e: any) => {
    setFormValue({ ...formValue, [e.target.name]: e.target.value })
  }
  const handleUpdate = () => {
    if (newPassword === newConfirmPassword) {
      dispatch(editUser({
        id: props.userId, name: newName, email: newEmail, password: newPassword
      }))
      toast.success("Profile updated successfully!")
    }
    else {
      toast.error("Password do not match!")
    }
  }

  return (
    <Box
      component="form"
      sx={{
        '& > :not(style)': { m: 1, width: '25ch' },
      }}
      noValidate
      autoComplete="off"
    >
      <TextField
        margin="normal"
        type="text"
        required
        fullWidth
        id="name"
        label="Type your name"
        name="name"
        autoFocus
        value={name} onChange={handleChange} />
      <TextField margin="normal"
        required
        fullWidth
        type="email"
        id="email"
        label="Type your email"
        name="email"
        value={email} onChange={handleChange} />
      <TextField margin="normal"
        required
        fullWidth
        type="password"
        id="password"
        label="Type your password"
        name="password"
        value={password} onChange={handleChange} />
      <TextField margin="normal"
        required
        fullWidth
        type="password"
        id="confirmPassword"
        label="Confirm password"
        name="confirmPassword"
        value={confirmPassword} onChange={handleChange} />
      <TextField margin="normal"
        required
        fullWidth
        type="file"
        id="file"
        name="file"
        value={avatar} onChange={handleChange} />
      <Button onClick={handleUpdate}>Submit</Button>
    </Box>
  )
}
export default ProfileForm