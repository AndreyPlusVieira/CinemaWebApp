import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './Shared/header/header.component';
import { FooterComponent } from './Shared/footer/footer.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { FramePageComponent } from './pages/master/frame.page';
import { HomeComponent } from './pages/home/home.component';
import { MoviesComponent } from './pages/movies/movies.component';
import { LoginComponent } from './pages/login/login.component';
import { RoomsComponent } from './pages/rooms/rooms.component';
import { SessionsComponent } from './pages/sessions/sessions.component';
import { MovieComponent } from './pages/movie/movie.component';
import { NewMovieComponent } from './pages/new-movie/new-movie.component';
import { UpdateMovieComponent } from './pages/update-movie/update-movie.component';
import { NewSessionComponent } from './pages/new-session/new-session.component';
import { UpdateSessionComponent } from './pages/update-session/update-session.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { NgxMaskModule, IConfig } from 'ngx-mask';
import { AuthService } from './services/auth.service';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    FooterComponent,
    FramePageComponent,
    HomeComponent,
    MoviesComponent,
    LoginComponent,
    RoomsComponent,
    SessionsComponent,
    MovieComponent,
    NewMovieComponent,
    UpdateMovieComponent,
    NewSessionComponent,
    UpdateSessionComponent,
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    FontAwesomeModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    NgxMaskModule.forRoot(),
  ],
  providers: [AuthService],
  bootstrap: [AppComponent],
})
export class AppModule {}
