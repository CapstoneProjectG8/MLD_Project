import { Helmet } from 'react-helmet-async';
import PageTitleWrapper from '../../../components/Dashboard/PageTitleWrapper';
import PageHeader from '../Crypto/PageHeader';
import { Container, Grid } from '@mui/material';
import Wallets from '../Crypto/Wallets';
import Footer from '../../../components/Dashboard/Footer';
import React from 'react';
import Icon from './Icon';

function Menu() {
  return(
    <>
      <Helmet>
        <title>Admin</title>
      </Helmet>
      <PageTitleWrapper>
        <PageHeader />
      </PageTitleWrapper>
      <Container maxWidth="lg">
        <Grid
          container
          direction="row"
          justifyContent="center"
          alignItems="stretch"
          spacing={4}
        >
          <Grid item xs={12}>
            <Icon />
          </Grid>
        </Grid>
      </Container>
      <Footer />
    </>
  )

}
export default Menu;