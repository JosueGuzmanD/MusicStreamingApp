import { useState } from 'react';
import {
  Box,
  Typography,
  Grid,
  Card,
  CardContent,
  CardMedia,
  Tabs,
  Tab,
  styled,
} from '@mui/material';

const StyledTabs = styled(Tabs)({
  marginBottom: '24px',
  '& .MuiTabs-indicator': {
    backgroundColor: '#1DB954',
  },
});

const StyledTab = styled(Tab)({
  color: 'gray',
  '&.Mui-selected': {
    color: 'white',
  },
});

const LibraryCard = styled(Card)({
  backgroundColor: '#282828',
  transition: 'background-color 0.3s',
  '&:hover': {
    backgroundColor: '#383838',
    cursor: 'pointer',
  },
});

const playlists = [
  { id: 1, title: 'Liked Songs', image: 'https://via.placeholder.com/200', type: 'Playlist', songs: '234 songs' },
  { id: 2, title: 'Your Top 2023', image: 'https://via.placeholder.com/200', type: 'Playlist', songs: '100 songs' },
  { id: 3, title: 'Discover Weekly', image: 'https://via.placeholder.com/200', type: 'Playlist', songs: '30 songs' },
  { id: 4, title: 'Release Radar', image: 'https://via.placeholder.com/200', type: 'Playlist', songs: '30 songs' },
];

const albums = [
  { id: 1, title: 'Album 1', image: 'https://via.placeholder.com/200', artist: 'Artist 1', year: '2023' },
  { id: 2, title: 'Album 2', image: 'https://via.placeholder.com/200', artist: 'Artist 2', year: '2023' },
  { id: 3, title: 'Album 3', image: 'https://via.placeholder.com/200', artist: 'Artist 3', year: '2022' },
  { id: 4, title: 'Album 4', image: 'https://via.placeholder.com/200', artist: 'Artist 4', year: '2022' },
];

const artists = [
  { id: 1, name: 'Artist 1', image: 'https://via.placeholder.com/200', followers: '1.2M followers' },
  { id: 2, name: 'Artist 2', image: 'https://via.placeholder.com/200', followers: '800K followers' },
  { id: 3, name: 'Artist 3', image: 'https://via.placeholder.com/200', followers: '2.5M followers' },
  { id: 4, name: 'Artist 4', image: 'https://via.placeholder.com/200', followers: '500K followers' },
];

function Library() {
  const [currentTab, setCurrentTab] = useState(0);

  const handleTabChange = (event, newValue) => {
    setCurrentTab(newValue);
  };

  const renderContent = () => {
    const items = currentTab === 0 ? playlists : currentTab === 1 ? albums : artists;

    return (
      <Grid container spacing={2}>
        {items.map((item) => (
          <Grid item xs={12} sm={6} md={3} key={item.id}>
            <LibraryCard>
              <CardMedia
                component="img"
                height="200"
                image={item.image}
                alt={item.title || item.name}
              />
              <CardContent>
                <Typography variant="subtitle1" component="div" color="white">
                  {item.title || item.name}
                </Typography>
                <Typography variant="body2" color="gray">
                  {item.songs || item.artist || item.followers}
                </Typography>
                {item.year && (
                  <Typography variant="body2" color="gray">
                    {item.year}
                  </Typography>
                )}
              </CardContent>
            </LibraryCard>
          </Grid>
        ))}
      </Grid>
    );
  };

  return (
    <Box sx={{ color: 'white' }}>
      <Typography variant="h4" fontWeight="bold" gutterBottom>
        Your Library
      </Typography>

      <StyledTabs value={currentTab} onChange={handleTabChange}>
        <StyledTab label="Playlists" />
        <StyledTab label="Albums" />
        <StyledTab label="Artists" />
      </StyledTabs>

      {renderContent()}
    </Box>
  );
}

export default Library; 