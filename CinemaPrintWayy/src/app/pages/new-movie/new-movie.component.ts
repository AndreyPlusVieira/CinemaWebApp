import { Component, OnInit } from '@angular/core';
import {
  FormBuilder,
  FormControl,
  FormGroup,
  Validators,
} from '@angular/forms';
import { Router } from '@angular/router';
import { RequestMovie } from 'src/app/models/Movies';
import { DataService } from 'src/app/services/data.service';

@Component({
  selector: 'app-new-movie',
  templateUrl: './new-movie.component.html',
  styleUrls: ['./new-movie.component.scss'],
})
export class NewMovieComponent implements OnInit {
  id: any;
  form: FormGroup;
  request: RequestMovie = {
    id: 0,
    title: '',
    description: '',
    image: '',
    duration: 0,
    active: true,
  };

  get f(): any {
    return this.form.controls;
  }

  constructor(
    private fb: FormBuilder,
    private data: DataService,
    private route: Router
  ) {}

  ngOnInit(): void {
    this.Validation();
  }

  save() {
    this.data.createMovie(this.request).subscribe((res) => {
      if (res.statusCode === 400) alert(res.value.toString());
      else alert(`Criado com Sucesso`);
    });
    this.route.navigate(['/movies']).then((nav) => {
      window.location.reload();
    });
  }

  public Validation(): void {
    this.form = this.fb.group({
      Title: ['', [Validators.required]],
      Description: ['', [Validators.required]],
      Duration: ['', [Validators.required, Validators.min(1)]],
    });
  }
}
