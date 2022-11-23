import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './pages/home/home.component';
import { LoginComponent } from './pages/login/login.component';
import { FramePageComponent } from './pages/master/frame.page';
import { MovieComponent } from './pages/movie/movie.component';
import { MoviesComponent } from './pages/movies/movies.component';
import { NewMovieComponent } from './pages/new-movie/new-movie.component';
import { NewSessionComponent } from './pages/new-session/new-session.component';
import { RoomsComponent } from './pages/rooms/rooms.component';
import { SessionsComponent } from './pages/sessions/sessions.component';
import { UpdateMovieComponent } from './pages/update-movie/update-movie.component';
import { UpdateSessionComponent } from './pages/update-session/update-session.component';
import { AuthService } from './services/auth.service';

const routes: Routes = [
  {
    path: '',
    component: FramePageComponent,
    children: [
      { path: '', component: HomeComponent },
      { path: 'home', component: HomeComponent },
      {
        path: 'movies',
        component: MoviesComponent,
        canActivate: [AuthService],
      },
      { path: 'rooms', component: RoomsComponent, canActivate: [AuthService] },
      {
        path: 'sessions',
        component: SessionsComponent,
        canActivate: [AuthService],
      },
    ],
  },
  {
    path: 'movie/:id',
    component: FramePageComponent,
    children: [
      { path: '', component: MovieComponent, canActivate: [AuthService] },
    ],
  },

  { path: 'login', component: LoginComponent },
  {
    path: 'new-movie',
    component: NewMovieComponent,
    canActivate: [AuthService],
  },
  {
    path: 'update-movie/:id',
    component: UpdateMovieComponent,
    canActivate: [AuthService],
  },
  {
    path: 'new-session',
    component: NewSessionComponent,
    canActivate: [AuthService],
  },
  {
    path: 'update-session/:id',
    component: UpdateSessionComponent,
    canActivate: [AuthService],
  },

  { path: '', redirectTo: 'home', pathMatch: 'full' },
  { path: '**', redirectTo: 'home', pathMatch: 'full' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
