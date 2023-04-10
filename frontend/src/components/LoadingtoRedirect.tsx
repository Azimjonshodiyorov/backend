import { useState, useEffect } from 'react'
import { useNavigate } from 'react-router-dom'

import { Grid, Typography } from '@mui/material'

const LoadingtoRedirect = () => {
  const [count, setCount] = useState(5)
  const navigate = useNavigate()
  useEffect(() => {
    const interval = setInterval(() => {
      setCount((currentCount) => currentCount - 1)

    }, 1000)
    count === 0 && navigate('/auth')
    return () => clearInterval(interval)
  }, [count, navigate])
  
  return (
    <Grid sx={{ display: "grid", alignContent: "center", justifyContent: "center", m:10 }}>
      <Typography variant="h4">Please Login</Typography>
      <Typography variant="h4">Redirecting you in {count}sec</Typography>
    </Grid>
  )
}
export default LoadingtoRedirect
