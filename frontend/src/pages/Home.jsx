import { Box, Grid, Typography, Card, CardContent, CardMedia, IconButton, styled } from '@mui/material';
import { IoPlayCircleOutline, IoTimeOutline, IoTrendingUpOutline, IoSparklesOutline } from 'react-icons/io5';

const Section = styled(Box)(({ theme }) => ({
  marginBottom: theme.spacing(8),
  position: 'relative',
}));

const PlaylistCard = styled(Card)(({ theme }) => ({
  height: '100%',
  background: theme.palette.background.paper,
  transition: 'all 0.3s cubic-bezier(0.4, 0, 0.2, 1)',
  position: 'relative',
  overflow: 'hidden',
  '&:hover': {
    transform: 'translateY(-8px)',
    '& .MuiCardMedia-root': {
      transform: 'scale(1.05)',
    },
    '& .play-button': {
      opacity: 1,
      transform: 'translate(-50%, -50%) scale(1)',
    },
  },
}));

const StyledCardMedia = styled(CardMedia)({
  transition: 'transform 0.3s cubic-bezier(0.4, 0, 0.2, 1)',
  height: 280,
});

const PlayButton = styled(IconButton)(({ theme }) => ({
  position: 'absolute',
  top: '50%',
  left: '50%',
  transform: 'translate(-50%, -50%) scale(0.8)',
  opacity: 0,
  transition: 'all 0.3s cubic-bezier(0.4, 0, 0.2, 1)',
  backgroundColor: theme.palette.primary.main,
  color: 'white',
  '&:hover': {
    backgroundColor: theme.palette.primary.dark,
    transform: 'translate(-50%, -50%) scale(1.1)',
  },
}));

const CategoryIcon = styled(Box)(({ theme }) => ({
  background: theme.palette.gradient.primary,
  borderRadius: '50%',
  width: 40,
  height: 40,
  display: 'flex',
  alignItems: 'center',
  justifyContent: 'center',
  marginBottom: theme.spacing(2),
  boxShadow: '0 4px 12px rgba(108, 99, 255, 0.2)',
}));

const featuredPlaylists = [
  { 
    id: 1, 
    title: 'Trending Now', 
    image: 'https://via.placeholder.com/400',
    description: 'The hottest tracks of the moment',
    icon: IoTrendingUpOutline,
  },
  { 
    id: 2, 
    title: 'Chill Vibes', 
    image: 'https://via.placeholder.com/400',
    description: 'Relaxing beats for your day',
    icon: IoSparklesOutline,
  },
  { 
    id: 3, 
    title: 'Time Machine', 
    image: 'https://via.placeholder.com/400',
    description: 'Throwback to the greatest hits',
    icon: IoTimeOutline,
  },
];

const recentlyPlayed = [
  { 
    id: 1, 
    title: 'Your Daily Mix', 
    image: 'https://via.placeholder.com/400',
    description: 'Personalized selection based on your taste',
    gradient: 'linear-gradient(45deg, #6C63FF, #FF6584)',
  },
  { 
    id: 2, 
    title: 'Discover Weekly', 
    image: 'https://via.placeholder.com/400',
    description: 'New music just for you',
    gradient: 'linear-gradient(45deg, #FF6584, #FFA07A)',
  },
  { 
    id: 3, 
    title: 'Genre Mix', 
    image: 'https://via.placeholder.com/400',
    description: 'A perfect blend of your favorite genres',
    gradient: 'linear-gradient(45deg, #6C63FF, #40E0D0)',
  },
];

function Home() {
  return (
    <Box>
      <Typography 
        variant="h4" 
        className="gradient-text"
        sx={{ mb: 6 }}
      >
        Discover New Music
      </Typography>

      <Section>
        <Typography 
          variant="h5" 
          sx={{ 
            mb: 4,
            display: 'flex',
            alignItems: 'center',
            gap: 2,
          }}
        >
          <CategoryIcon>
            <IoSparklesOutline size={24} color="white" />
          </CategoryIcon>
          Featured Playlists
        </Typography>
        <Grid container spacing={4}>
          {featuredPlaylists.map((playlist) => (
            <Grid item xs={12} sm={6} md={4} key={playlist.id}>
              <PlaylistCard>
                <Box sx={{ position: 'relative' }}>
                  <StyledCardMedia
                    image={playlist.image}
                    title={playlist.title}
                  />
                  <PlayButton className="play-button" size="large">
                    <IoPlayCircleOutline size={32} />
                  </PlayButton>
                </Box>
                <CardContent>
                  <Box sx={{ display: 'flex', alignItems: 'center', gap: 1, mb: 1 }}>
                    <playlist.icon size={20} color="#6C63FF" />
                    <Typography variant="subtitle1" fontWeight={600}>
                      {playlist.title}
                    </Typography>
                  </Box>
                  <Typography variant="body2" color="text.secondary">
                    {playlist.description}
                  </Typography>
                </CardContent>
              </PlaylistCard>
            </Grid>
          ))}
        </Grid>
      </Section>

      <Section>
        <Typography 
          variant="h5" 
          sx={{ mb: 4 }}
        >
          Made For You
        </Typography>
        <Grid container spacing={4}>
          {recentlyPlayed.map((item) => (
            <Grid item xs={12} sm={6} md={4} key={item.id}>
              <PlaylistCard
                sx={{
                  background: item.gradient,
                  color: 'white',
                }}
              >
                <Box sx={{ position: 'relative' }}>
                  <StyledCardMedia
                    image={item.image}
                    title={item.title}
                    sx={{ 
                      height: 200,
                      opacity: 0.8,
                    }}
                  />
                  <PlayButton className="play-button" size="large">
                    <IoPlayCircleOutline size={32} />
                  </PlayButton>
                </Box>
                <CardContent>
                  <Typography variant="subtitle1" fontWeight={600} color="inherit">
                    {item.title}
                  </Typography>
                  <Typography variant="body2" color="rgba(255, 255, 255, 0.8)">
                    {item.description}
                  </Typography>
                </CardContent>
              </PlaylistCard>
            </Grid>
          ))}
        </Grid>
      </Section>
    </Box>
  );
}

export default Home; 