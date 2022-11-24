import { ChangeDetectorRef, Component, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';

import { Movie, RequestMovie } from 'src/app/models/Movies';
import { DataService } from 'src/app/services/data.service';

@Component({
  selector: 'app-update-movie',
  templateUrl: './update-movie.component.html',
  styleUrls: ['./update-movie.component.scss'],
})
export class UpdateMovieComponent implements OnInit {
  id: any;
  form: FormGroup;
  request: RequestMovie = {
    id: 0,
    title: '',
    description: '',
    image: '',
    duration: 1,
    active: true,
  };

  get f(): any {
    return this.form.controls;
  }

  constructor(
    private cd: ChangeDetectorRef,
    private fb: FormBuilder,
    private data: DataService,
    private route: Router,
    private router: ActivatedRoute
  ) {}

  ngOnInit(): void {
    this.Validation();
    this.findId();
  }
  ngAfterViewChecked() {
    this.cd.detectChanges();
  }

  findId() {
    this.id = this.router.snapshot.paramMap.get('id');

    this.data.getMoviesById(this.id).subscribe((res) => {
      this.request = {
        id: res.value.id,
        title: res.value.title,
        description: res.value.description,
        image: res.value.image,
        duration: res.value.duration,
        active: res.value.active,
      };
    });
  }

  public Validation(): void {
    this.form = this.fb.group({
      Title: ['', [Validators.required]],
      Description: ['', [Validators.required]],
      Duration: ['', [Validators.required]],
    });
  }

  update() {
    this.data.updateMovie(this.id, this.request).subscribe((res) => {
      if (res.statusCode === 400) alert(res.value);
      else alert(`Atualizado`);
    });
    this.route.navigate([`/movie/${this.id}`]).then((nav) => {
      window.location.reload();
    });
  }
}
