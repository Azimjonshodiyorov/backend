import { useEffect, useState } from 'react'
import { useNavigate } from 'react-router-dom'
import { useAppDispatch, useAppSelector } from '../hooks/reduxHook'

import { Box, Typography, Paper, styled, Button } from '@mui/material'

import Header from "./Header"

import { addToCart } from '../redux/reducer/cartReducer'
import { selectAuth } from '../redux/reducer/authReducer'

const ProductDetail = (props: any) => {
  const dispatch = useAppDispatch()
  const navigate = useNavigate()
  const [product, setProduct] = useState({ id: 0, title: "", images: [''], price: 0, description: "" })
  const { token } = useAppSelector(selectAuth)
  const Item = styled(Paper)(({ theme }) => ({
    backgroundColor: theme.palette.mode === 'dark' ? '#1A2027' : '#fff',
    ...theme.typography.body2,
    padding: theme.spacing(1),
    textAlign: 'center',
    color: theme.palette.text.secondary,
  }))
  const productId = props.detailedPId
  useEffect(() => {
    const fetchData = async (id: number) => {
      try {
        const response = await fetch(`https://api.escuelajs.co/api/v1/products/${id}`);
        const json = await response.json();
        setProduct(json)
      } catch (error) {
        console.log("error", error);
      }
    }
    fetchData(productId);
  }, [productId]);

  const handleOpen = (e: React.ChangeEvent<HTMLSelectElement> | any) => {
  }
  const handleCart = (product: any) => {
    if (token) {
      dispatch(addToCart(product))
    }
    else {
      navigate('/private')
    }
  }

  return (
    <>
      <Header />
      <Box sx={{ display: 'grid', gap: 8, gridTemplateColumns: 'repeat(2, 1fr)', margin: "4rem" }} >
        <Item key={product.id}>
          <Box sx={{ width: "100%" }} component='img' src={product.images[0]} id="product_img"></Box>
          <Typography variant='subtitle1' sx={{ fontWeight: 'bold' }}>{product.title}</Typography>
          <Button type="submit" variant="contained" sx={{ mt: 3, mb: 2 }} onClick={() => handleCart(product)}>
            Add To Cart
          </Button>
        </Item>
        <Item>
          <Typography variant='subtitle1' sx={{ fontWeight: 'bold', textAlign: 'left' }}>{product.description}</Typography>
          <Typography variant='subtitle1' sx={{ fontWeight: 'bold', fontSize: 35, textAlign: 'left' }}>{product.price}€</Typography>
          <Button type="submit" variant="outlined" sx={{ mt: 3, mb: 2 }} onClick={(e) => handleOpen(e)}>Read Reviews</Button>
        </Item>
      </Box>
    </>
  )
}

export default ProductDetail