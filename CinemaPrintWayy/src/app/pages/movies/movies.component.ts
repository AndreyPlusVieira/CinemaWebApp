import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ResponseMovies } from 'src/app/models/Movies';
import { DataService } from 'src/app/services/data.service';

@Component({
  selector: 'app-movies',
  templateUrl: './movies.component.html',
  styleUrls: ['./movies.component.scss'],
})
export class MoviesComponent implements OnInit {
  id: any;
  movie: ResponseMovies;
  filterMovie: ResponseMovies['value'] = [];
  _filterList: string = '';

  public get filterList(): string {
    return this._filterList;
  }

  public set filterList(value: string) {
    this._filterList = value;
    this.filterMovie = this.filterList
      ? this.filterMovies(this.filterList)
      : this.movie.value;
  }

  filterMovies(filterBy: string): ResponseMovies['value'] {
    return this.movie.value.filter(
      (movie: any) => movie.title.toLocaleLowerCase().indexOf(filterBy) !== -1
    );
  }

  constructor(
    private data: DataService,
    private activeRouter: ActivatedRoute,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.recoverId();
    this.getMovies();
  }

  recoverId() {
    this.id = this.activeRouter.snapshot.paramMap.get('id');
  }

  public getMovies(): void {
    this.data.getMovies().subscribe(
      (res: ResponseMovies) => {
        this.movie = res;
        this.filterMovie = this.movie.value;
      },

      (err: any) => console.log(err)
    );
  }

  deleteMovie(id: number) {
    const idConvert = id.toString();
    const question = confirm('deseja realmente deletar o Filme?');
    if (question == true) {
      this.data.deleteMovie(idConvert).subscribe((res: ResponseMovies) => {
        if (res.statusCode === 400) alert(res.value);
        else window.location.reload();
      });
    } else {
      alert('Filme Mantido');
    }
  }
}
