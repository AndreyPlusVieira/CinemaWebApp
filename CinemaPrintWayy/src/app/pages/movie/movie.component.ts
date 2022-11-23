import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Movie } from 'src/app/models/Movies';
import { ResponseSession } from 'src/app/models/Session';
import { DataService } from 'src/app/services/data.service';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-movie',
  templateUrl: './movie.component.html',
  styleUrls: ['./movie.component.scss'],
})
export class MovieComponent implements OnInit {
  id: any;
  url = 'https://localhost:7116';
  request: Movie | undefined;
  responseSessions: ResponseSession;

  imageURl = '../../../assets/Images/PopCorn.png';
  file: File;

  constructor(private router: ActivatedRoute, private data: DataService) {}

  ngOnInit(): void {
    this.findId();
    this.findMovieById();
    this.findSessionByMovieId();
  }

  findId() {
    this.id = this.router.snapshot.paramMap.get('id');
  }

  findMovieById() {
    this.data.getMoviesById(this.id).subscribe((res) => {
      this.request = {
        id: res.value.id,
        title: res.value.title,
        description: res.value.description,
        image: res.value.image,
        duration: res.value.duration,
        active: res.value.active,
      };

      if (this.request.image !== '') {
        this.imageURl =
          'https://localhost:7116/resources/images/' + res.value.image;
      }
    });
  }

  findSessionByMovieId() {
    this.data.getSessionByMovieId(this.id).subscribe(
      (res) => (this.responseSessions = res),
      (err: any) => console.log(err)
    );
  }

  onFileChange(event: Event): void {
    const target = event.target as HTMLInputElement;
    const files = target.files as FileList;

    const reader = new FileReader();

    reader.onload = (evento: any) => (this.imageURl = evento.target.result);

    this.file = files.item(0) as File;
    reader.readAsDataURL(this.file);

    this.uploadImage();
  }

  uploadImage(): void {
    this.data.postUpload(this.id, this.file).subscribe(
      () => {},
      () => {}
    );
  }
}
