import { useState } from 'react';
import { Box, IconButton, Slider, Typography, styled } from '@mui/material';
import {
  IoPlayCircleOutline,
  IoPauseCircleOutline,
  IoPlaySkipForwardOutline,
  IoPlaySkipBackOutline,
  IoVolumeHighOutline,
  IoShuffleOutline,
  IoRepeatOutline,
} from 'react-icons/io5';

const PlayerContainer = styled(Box)(({ theme }) => ({
  gridArea: 'player',
  backgroundColor: theme.palette.background.paper,
  padding: theme.spacing(2, 4),
  display: 'flex',
  alignItems: 'center',
  justifyContent: 'space-between',
  boxShadow: '0 -4px 24px rgba(108, 99, 255, 0.08)',
  position: 'relative',
  zIndex: 1,
  '&::before': {
    content: '""',
    position: 'absolute',
    top: 0,
    left: 0,
    right: 0,
    height: '1px',
    background: theme.palette.gradient.primary,
  },
}));

const SongInfo = styled(Box)({
  display: 'flex',
  alignItems: 'center',
  gap: '1.5rem',
  width: '30%',
});

const Controls = styled(Box)({
  display: 'flex',
  flexDirection: 'column',
  alignItems: 'center',
  width: '40%',
});

const PlaybackControls = styled(Box)({
  display: 'flex',
  alignItems: 'center',
  gap: '2rem',
  marginBottom: '0.75rem',
});

const VolumeControls = styled(Box)({
  display: 'flex',
  alignItems: 'center',
  gap: '1rem',
  width: '30%',
  justifyContent: 'flex-end',
});

const StyledIconButton = styled(IconButton)(({ theme, active }) => ({
  color: active ? theme.palette.primary.main : theme.palette.text.primary,
  transition: 'all 0.3s cubic-bezier(0.4, 0, 0.2, 1)',
  '&:hover': {
    transform: 'scale(1.1)',
    color: theme.palette.primary.main,
  },
}));

const StyledSlider = styled(Slider)(({ theme }) => ({
  color: theme.palette.primary.main,
  height: 4,
  '& .MuiSlider-thumb': {
    width: 12,
    height: 12,
    transition: '0.2s cubic-bezier(.47,1.64,.41,.8)',
    '&:hover, &.Mui-focusVisible': {
      boxShadow: `0 0 0 8px ${theme.palette.primary.main}20`,
    },
    '&.Mui-active': {
      width: 16,
      height: 16,
    },
  },
  '& .MuiSlider-rail': {
    opacity: 0.3,
  },
  '& .MuiSlider-track': {
    background: theme.palette.gradient.primary,
  },
}));

const AlbumArt = styled(Box)(({ theme }) => ({
  width: 64,
  height: 64,
  borderRadius: theme.shape.borderRadius,
  overflow: 'hidden',
  boxShadow: '0 8px 16px rgba(108, 99, 255, 0.2)',
  position: 'relative',
  '&::after': {
    content: '""',
    position: 'absolute',
    top: 0,
    left: 0,
    right: 0,
    bottom: 0,
    background: 'linear-gradient(45deg, rgba(108, 99, 255, 0.2), rgba(255, 101, 132, 0.2))',
    mixBlendMode: 'overlay',
  },
}));

function Player() {
  const [isPlaying, setIsPlaying] = useState(false);
  const [volume, setVolume] = useState(70);
  const [progress, setProgress] = useState(0);

  return (
    <PlayerContainer className="glass-effect">
      <SongInfo>
        <AlbumArt>
          <Box
            component="img"
            src="https://via.placeholder.com/64"
            alt="Album cover"
            sx={{ width: '100%', height: '100%', objectFit: 'cover' }}
          />
        </AlbumArt>
        <Box>
          <Typography variant="subtitle1" color="text.primary" fontWeight={600}>
            Song Title
          </Typography>
          <Typography variant="body2" color="text.secondary">
            Artist Name
          </Typography>
        </Box>
      </SongInfo>

      <Controls>
        <PlaybackControls>
          <StyledIconButton size="small">
            <IoShuffleOutline size={18} />
          </StyledIconButton>
          <StyledIconButton>
            <IoPlaySkipBackOutline size={24} />
          </StyledIconButton>
          <StyledIconButton 
            onClick={() => setIsPlaying(!isPlaying)}
            active={isPlaying}
            sx={{ 
              background: isPlaying ? 'rgba(108, 99, 255, 0.1)' : 'transparent',
              '&:hover': {
                background: 'rgba(108, 99, 255, 0.15)',
              }
            }}
          >
            {isPlaying ? (
              <IoPauseCircleOutline size={48} />
            ) : (
              <IoPlayCircleOutline size={48} />
            )}
          </StyledIconButton>
          <StyledIconButton>
            <IoPlaySkipForwardOutline size={24} />
          </StyledIconButton>
          <StyledIconButton size="small">
            <IoRepeatOutline size={18} />
          </StyledIconButton>
        </PlaybackControls>
        <Box sx={{ width: '100%', display: 'flex', alignItems: 'center', gap: 1 }}>
          <Typography variant="caption" color="text.secondary">
            {Math.floor(progress / 60)}:{String(progress % 60).padStart(2, '0')}
          </Typography>
          <StyledSlider
            size="small"
            value={progress}
            onChange={(_, value) => setProgress(value)}
            max={225}
          />
          <Typography variant="caption" color="text.secondary">3:45</Typography>
        </Box>
      </Controls>

      <VolumeControls>
        <StyledIconButton size="small">
          <IoVolumeHighOutline size={20} />
        </StyledIconButton>
        <StyledSlider
          size="small"
          value={volume}
          onChange={(_, value) => setVolume(value)}
          sx={{ width: 100 }}
        />
      </VolumeControls>
    </PlayerContainer>
  );
}

export default Player; 