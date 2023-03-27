import { useAppDispatch, useAppSelector } from '../hooks/reduxHook'
import { useEffect } from 'react'
import { useNavigate, Link } from 'react-router-dom'

import "react-responsive-carousel/lib/styles/carousel.min.css";
import { Carousel } from 'react-responsive-carousel';
import ImageList from '@mui/material/ImageList';
import ImageListItem from '@mui/material/ImageListItem';
import ImageListItemBar from '@mui/material/ImageListItemBar';
import IconButton from '@mui/material/IconButton';
import InfoIcon from '@mui/icons-material/Info';
import { Box, Grid, Typography, Button } from '@mui/material'

import Header from "./Header"

import { fetchFeaturedProducts } from '../redux/reducer/productReducer'

const EntryPage = (props: any) => {
    const dispatch = useAppDispatch()
    const navigate = useNavigate()
    const products = useAppSelector(state => state.productReducer)
    useEffect(() => {
        dispatch(fetchFeaturedProducts())
    }, [])
    const handleClick = () => {
        navigate('/home')
    }
    const handleSelect = (productId: number) => {
        props.idSelected(productId);
        navigate(`/product/${productId}`)
    }

    return (
        <>
            <Header />
            <Grid>
                <Carousel autoPlay showThumbs={false}>
                    <Grid sx={{ height: "70vh" }}>
                        <img src={window.location.origin + '/assets/hero3.jpg'} />
                        <div style={{ position: "absolute", color: "white", top: 90, left: "20%", fontSize: "45px" }}>
                            Explore the world of Online Shopping
                            <br />
                            <Button>
                                <Link style={{ textDecoration: "none", color: "white", fontWeight: "bold", margin: 10 }} to={'/home'}>Visit our store..</Link>
                            </Button>
                        </div></Grid>
                    <Grid sx={{ height: "70vh" }}>
                        <img src={window.location.origin + '/assets/hero2.jpg'} />
                        <div style={{ position: "absolute", color: "white", top: 90, left: "40%", fontSize: "45px" }}>
                            Awesome products
                            <br />
                            <Button>
                                <Link style={{ textDecoration: "none", color: "white", fontWeight: "bold", margin: 10 }} to={'/home'}>Visit our store..</Link>
                            </Button>
                        </div>
                    </Grid>
                    <Grid sx={{ height: "70vh" }}>
                        <img src={window.location.origin + '/assets/hero1.jpg'} />
                        <div style={{
                            position: "absolute", color: "white", top: 90, left: "20%", fontSize: "45px",
                            fontFamily: "sans-serif",
                            fontStretch: "expanded"
                        }}>
                            Always deliver more than expected
                            <br />
                            <Button>
                                <Link style={{ textDecoration: "none", color: "white", fontWeight: "bold", margin: 10 }} to={'/home'}>Visit our store..</Link>
                            </Button>
                        </div>
                    </Grid>
                </Carousel>
            </Grid>
            <Box className="body" sx={{ display: 'grid', justifyContent: "center", textAlign: "center", mt: 8 }}>
                <Box>
                    <Typography variant="overline" sx={{ fontWeight: 'bold', fontSize: 25, m: 7 }} >
                        Our Featured products
                    </Typography>
                </Box>
                <Grid>
                    <ImageList cols={4} gap={20} sx={{ width: 800, height: 450, m: 4 }}>
                        {products.map((item) => (
                            <ImageListItem key={item.id}>
                                <img
                                    src={item.images[0]}
                                    alt={item.title}
                                    loading="lazy"
                                />
                                <ImageListItemBar onClick={(e) => handleSelect(item.id)}
                                    title={item.title}
                                    subtitle={item.description}
                                    actionIcon={
                                        <IconButton
                                            sx={{ color: 'rgba(255, 255, 255, 0.54)' }}
                                            aria-label={`info about ${item.title}`}
                                        >
                                            <InfoIcon />
                                        </IconButton>
                                    }
                                />
                            </ImageListItem>
                        ))}
                    </ImageList>
                </Grid>
                <Box>
                    <Button variant="text" sx={{ fontWeight: 'normal', fontSize: 15, m: 5 }} component="div"
                        onClick={handleClick}>
                        More Products
                    </Button>
                </Box>
            </Box>
        </>
    )
}

export default EntryPage