import { useState } from 'react';
import {
  Box,
  TextField,
  Typography,
  Grid,
  Card,
  CardContent,
  CardMedia,
  InputAdornment,
  styled,
} from '@mui/material';
import { IoSearchOutline } from 'react-icons/io5';

const SearchTextField = styled(TextField)(({ theme }) => ({
  marginBottom: theme.spacing(4),
  '& .MuiOutlinedInput-root': {
    color: 'white',
    backgroundColor: '#282828',
    '&:hover': {
      backgroundColor: '#383838',
    },
    '& fieldset': {
      borderColor: 'transparent',
    },
    '&:hover fieldset': {
      borderColor: 'transparent',
    },
    '&.Mui-focused fieldset': {
      borderColor: theme.palette.primary.main,
    },
  },
}));

const ResultCard = styled(Card)({
  backgroundColor: '#282828',
  transition: 'background-color 0.3s',
  '&:hover': {
    backgroundColor: '#383838',
    cursor: 'pointer',
  },
});

const categories = [
  { id: 1, title: 'Pop', color: '#FF4081' },
  { id: 2, title: 'Hip-Hop', color: '#7C4DFF' },
  { id: 3, title: 'Rock', color: '#FF5252' },
  { id: 4, title: 'Electronic', color: '#40C4FF' },
  { id: 5, title: 'Latin', color: '#FFD740' },
  { id: 6, title: 'Jazz', color: '#64FFDA' },
  { id: 7, title: 'Classical', color: '#FF6E40' },
  { id: 8, title: 'R&B', color: '#69F0AE' },
];

function Search() {
  const [searchQuery, setSearchQuery] = useState('');
  const [searchResults] = useState([]); // In a real app, this would be populated from an API call

  return (
    <Box sx={{ color: 'white' }}>
      <SearchTextField
        fullWidth
        placeholder="What do you want to listen to?"
        value={searchQuery}
        onChange={(e) => setSearchQuery(e.target.value)}
        InputProps={{
          startAdornment: (
            <InputAdornment position="start">
              <IoSearchOutline color="white" size={24} />
            </InputAdornment>
          ),
        }}
      />

      {!searchQuery && (
        <>
          <Typography variant="h5" fontWeight="bold" gutterBottom>
            Browse All
          </Typography>
          <Grid container spacing={2}>
            {categories.map((category) => (
              <Grid item xs={6} sm={4} md={3} key={category.id}>
                <ResultCard sx={{ backgroundColor: category.color }}>
                  <CardContent>
                    <Typography variant="h6" component="div" color="white" fontWeight="bold">
                      {category.title}
                    </Typography>
                  </CardContent>
                </ResultCard>
              </Grid>
            ))}
          </Grid>
        </>
      )}

      {searchQuery && searchResults.length > 0 && (
        <Grid container spacing={2}>
          {searchResults.map((result) => (
            <Grid item xs={12} sm={6} md={3} key={result.id}>
              <ResultCard>
                <CardMedia
                  component="img"
                  height="200"
                  image={result.image}
                  alt={result.title}
                />
                <CardContent>
                  <Typography variant="subtitle1" component="div" color="white">
                    {result.title}
                  </Typography>
                  <Typography variant="body2" color="gray">
                    {result.artist}
                  </Typography>
                </CardContent>
              </ResultCard>
            </Grid>
          ))}
        </Grid>
      )}

      {searchQuery && searchResults.length === 0 && (
        <Box sx={{ textAlign: 'center', mt: 4 }}>
          <Typography variant="h6" color="gray">
            No results found for "{searchQuery}"
          </Typography>
          <Typography variant="body1" color="gray">
            Please try another search term
          </Typography>
        </Box>
      )}
    </Box>
  );
}

export default Search; 