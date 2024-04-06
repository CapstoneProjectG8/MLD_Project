import React from 'react';
import { Button, Card, Grid, Box, CardContent, Typography, Avatar, alpha, Tooltip, CardActionArea, styled } from '@mui/material';
import AddTwoToneIcon from '@mui/icons-material/AddTwoTone';

const AvatarWrapper = styled(Avatar)(({ theme }) => ({
  margin: theme.spacing(2, 0, 1, -0.5),
  display: 'flex',
  alignItems: 'center',
  justifyContent: 'center',
  marginRight: theme.spacing(1),
  padding: theme.spacing(0.5),
  borderRadius: 4,
  height: theme.spacing(27),
  width: theme.spacing(27),
  background: theme.palette.mode === 'dark' ? theme.palette.grey[800] : alpha(theme.palette.grey[200], 0.07),
  '& img': {
    background: theme.palette.grey[100],
    display: 'block',
    height: theme.spacing(25.5),
    width: theme.spacing(25.5),
  },
  '@media (max-width: 768px)': {
    borderRadius: 0,
  },
}));

const AvatarAddWrapper = styled(Avatar)(({ theme }) => ({
  background: theme.palette.grey[100],
  color: theme.palette.primary.main,
  width: theme.spacing(8),
  height: theme.spacing(8),
}));

const CardAddAction = styled(Card)(({ theme }) => ({
  border: `1px dashed ${theme.palette.primary.main}`,
  height: '100%',
  color: theme.palette.primary.main,
  transition: theme.transitions.create(['border-color']),
  '.MuiCardActionArea-root': {
    height: '100%',
    justifyContent: 'center',
    alignItems: 'center',
    display: 'flex',
  },
  '.MuiTouchRipple-root': {
    opacity: 0.2,
  },
  '&:hover': {
    borderColor: theme.palette.grey[700],
  },
}));

function Wallets() {
  return (
    <>
      <Box display="flex" alignItems="center" justifyContent="space-between" sx={{ pb: 3 }}>
        <Typography variant="h3">E-Learning</Typography>
        <Button size="small" variant="outlined" startIcon={<AddTwoToneIcon fontSize="small" />}>
          Add new E-Learning
        </Button>
      </Box>
      <Grid container spacing={3}>
        <Grid xs={12} sm={6} md={3} item>
          <Card sx={{ px: 1 }}>
            <CardContent>
              <AvatarWrapper>
                <img
                  alt="E-Learning"
                  src="https://image.freepik.com/free-vector/e-learning-icons-flat_1284-3950.jpg"
                />
              </AvatarWrapper>
              <Box sx={{ pt: 3 }}>
                <Typography variant="h4" gutterBottom>
                  Quy trình xây dựng bài giảng E-learning cho doanh nghiệp 2021
                </Typography>
                <Typography variant="subtitle2" noWrap>
                  E-Learning
                </Typography>
              </Box>
            </CardContent>
          </Card>
        </Grid>
        <Grid xs={12} sm={6} md={3} item>
          <Tooltip arrow title="Click to add a new e-learning">
            <CardAddAction>
              <CardActionArea sx={{ px: 1 }}>
                <CardContent>
                  <AvatarAddWrapper>
                    <AddTwoToneIcon fontSize="large" />
                  </AvatarAddWrapper>
                </CardContent>
              </CardActionArea>
            </CardAddAction>
          </Tooltip>
        </Grid>
      </Grid>
    </>
  );
}

export default Wallets;
