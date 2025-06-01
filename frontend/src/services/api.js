import axios from 'axios';

const API_BASE_URL = 'http://localhost:5000/api'; // Adjust this to match your .NET backend URL

const api = axios.create({
  baseURL: API_BASE_URL,
  headers: {
    'Content-Type': 'application/json',
  },
});

// Add a request interceptor for authentication
api.interceptors.request.use(
  (config) => {
    const token = localStorage.getItem('token');
    if (token) {
      config.headers.Authorization = `Bearer ${token}`;
    }
    return config;
  },
  (error) => {
    return Promise.reject(error);
  }
);

export const musicApi = {
  // Authentication
  login: (credentials) => api.post('/auth/login', credentials),
  register: (userData) => api.post('/auth/register', userData),

  // Songs
  getSongs: () => api.get('/songs'),
  getSongById: (id) => api.get(`/songs/${id}`),
  searchSongs: (query) => api.get(`/songs/search?q=${query}`),

  // Playlists
  getPlaylists: () => api.get('/playlists'),
  getPlaylistById: (id) => api.get(`/playlists/${id}`),
  createPlaylist: (playlistData) => api.post('/playlists', playlistData),
  updatePlaylist: (id, playlistData) => api.put(`/playlists/${id}`, playlistData),
  deletePlaylist: (id) => api.delete(`/playlists/${id}`),

  // Artists
  getArtists: () => api.get('/artists'),
  getArtistById: (id) => api.get(`/artists/${id}`),
  getArtistAlbums: (id) => api.get(`/artists/${id}/albums`),

  // Albums
  getAlbums: () => api.get('/albums'),
  getAlbumById: (id) => api.get(`/albums/${id}`),
  getAlbumSongs: (id) => api.get(`/albums/${id}/songs`),

  // User Library
  getLikedSongs: () => api.get('/me/tracks'),
  addToLikedSongs: (songId) => api.post(`/me/tracks/${songId}`),
  removeFromLikedSongs: (songId) => api.delete(`/me/tracks/${songId}`),

  // Recently Played
  getRecentlyPlayed: () => api.get('/me/recently-played'),
  addToRecentlyPlayed: (songId) => api.post(`/me/recently-played/${songId}`),
};

export default musicApi; 