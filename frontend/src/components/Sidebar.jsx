import { Link, useLocation } from 'react-router-dom';
import { Box, List, ListItem, ListItemIcon, ListItemText, Typography, styled } from '@mui/material';
import { IoMusicalNotesOutline, IoCompassOutline, IoGridOutline, IoHeartOutline } from 'react-icons/io5';

const SidebarContainer = styled(Box)(({ theme }) => ({
  gridArea: 'sidebar',
  backgroundColor: theme.palette.background.paper,
  padding: theme.spacing(4),
  display: 'flex',
  flexDirection: 'column',
  gap: theme.spacing(6),
  boxShadow: '4px 0 24px rgba(108, 99, 255, 0.08)',
  position: 'relative',
  zIndex: 1,
}));

const Logo = styled(Box)({
  display: 'flex',
  alignItems: 'center',
  gap: '12px',
  marginBottom: '32px',
});

const LogoIcon = styled(Box)(({ theme }) => ({
  background: theme.palette.gradient.primary,
  borderRadius: '14px',
  padding: '10px',
  display: 'flex',
  alignItems: 'center',
  justifyContent: 'center',
  boxShadow: '0 4px 12px rgba(108, 99, 255, 0.2)',
}));

const StyledListItem = styled(ListItem)(({ theme, active }) => ({
  borderRadius: theme.shape.borderRadius,
  marginBottom: '8px',
  padding: '12px 16px',
  color: active ? theme.palette.primary.main : theme.palette.text.primary,
  backgroundColor: active ? 'rgba(108, 99, 255, 0.08)' : 'transparent',
  '&:hover': {
    backgroundColor: 'rgba(108, 99, 255, 0.05)',
    transform: 'translateX(4px)',
  },
  '& .MuiListItemIcon-root': {
    color: 'inherit',
    minWidth: '40px',
  },
  '& .MuiListItemText-primary': {
    fontWeight: active ? 600 : 500,
    fontSize: '0.95rem',
  },
  transition: 'all 0.3s cubic-bezier(0.4, 0, 0.2, 1)',
}));

const menuItems = [
  { text: 'Discover', icon: IoCompassOutline, path: '/' },
  { text: 'Browse', icon: IoGridOutline, path: '/search' },
  { text: 'Collection', icon: IoHeartOutline, path: '/library' },
];

function Sidebar() {
  const location = useLocation();

  return (
    <SidebarContainer>
      <Logo>
        <LogoIcon>
          <IoMusicalNotesOutline size={24} color="white" />
        </LogoIcon>
        <Typography variant="h6" className="gradient-text">
          Melodia
        </Typography>
      </Logo>
      <List>
        {menuItems.map((item) => (
          <StyledListItem
            key={item.text}
            component={Link}
            to={item.path}
            active={location.pathname === item.path ? 1 : 0}
          >
            <ListItemIcon>
              <item.icon size={22} />
            </ListItemIcon>
            <ListItemText primary={item.text} />
          </StyledListItem>
        ))}
      </List>
    </SidebarContainer>
  );
}

export default Sidebar; 