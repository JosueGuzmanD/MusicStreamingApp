# MusicStreamingApp

## 🎵 Overview

**MusicStreamingApp** is a full-stack application designed to provide a seamless music streaming experience. It aims to replicate the functionality of popular platforms like Spotify, allowing users to:

- Search for songs, artists, and playlists.
- Stream music on demand.
- Create and manage custom playlists.
- Register, log in, and manage user accounts.

The application is being developed with a focus on **Domain-Driven Design (DDD)** and **Clean Architecture**, ensuring scalability, maintainability, and clear separation of concerns.

---

## 🛠️ Tech Stack

### Backend:
- **.NET 9**: For building a scalable and robust REST API.
- **Entity Framework Core**: For database management and object-relational mapping (ORM).
- **ASP.NET Identity**: For authentication and authorization.
- **SQL Server**: As the primary database.

### Frontend:
- **React Native**: For building a cross-platform mobile application.
- **Redux**: For state management.

---

## 📂 Project Structure

The project follows **Clean Architecture** principles with clear separation of layers:

```
/src
|-- /Core          # Domain layer (Entities, Value Objects, Domain Services)
|-- /Application   # Application layer (Use Cases, DTOs, Interfaces)
|-- /Infrastructure # Infrastructure layer (Persistence, Repositories, External APIs)
|-- /API           # Presentation layer (Controllers, Middleware)
```

### Core Components:
- **Entities**: Represent the core business models (e.g., `Song`, `Artist`, `Playlist`, `User`).
- **Value Objects**: Encapsulate domain-specific values (e.g., `Email`, `PhoneNumber`, `Duration`).
- **Use Cases**: Encapsulate application-specific operations (e.g., "Search for songs", "Create playlist").

---

## 🌟 Key Features

### 1. User Management
- Register and log in with ASP.NET Identity.
- Manage user accounts and preferences.

### 2. Music Library
- Stream songs from a vast library.
- Search for songs, artists, and albums.

### 3. Playlists
- Create, update, and delete custom playlists.
- Add or remove songs from playlists.

### 4. Streaming
- Real-time audio playback with smooth transitions.
- Support for cross-device streaming.

---

## 📜 Roadmap

1. **Phase 1**: Backend foundation (authentication, core entities, streaming endpoints).
2. **Phase 2**: Frontend implementation (React Native UI, Redux state management).
3. **Phase 3**: Integration and testing (API + frontend).
4. **Phase 4**: Deploy to production.

---
