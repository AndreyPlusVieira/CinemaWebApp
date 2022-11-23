import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Movie } from 'src/app/models/Movies';
import { ResponseSession, ResponseSessionUpdate } from 'src/app/models/Session';
import { DataService } from 'src/app/services/data.service';

@Component({
  selector: 'app-sessions',
  templateUrl: './sessions.component.html',
  styleUrls: ['./sessions.component.scss'],
})
export class SessionsComponent implements OnInit {
  id: any;
  session: ResponseSession;
  requestMovie: Movie | undefined;

  filterSession: ResponseSession['value'] = [];
  _filterList: any;

  public get filterList(): any {
    return this._filterList;
  }

  public set filterList(value: any) {
    this._filterList = value;
    this.filterSession = this.filterList
      ? this.filterSessions(this.filterList)
      : this.session.value;
  }

  filterSessions(filterBy: any): ResponseSession['value'] {
    return this.session.value.filter(
      (session: any) =>
        session.startTime.toLocaleLowerCase().indexOf(filterBy) !== -1 ||
        session.audioType.toLocaleLowerCase().indexOf(filterBy) !== -1 ||
        session.animationType.toLocaleLowerCase().indexOf(filterBy) !== -1 ||
        session.movieId.toString().toLocaleLowerCase().indexOf(filterBy) !== -1
    );
  }

  constructor(
    private data: DataService,
    private activeRouter: ActivatedRoute,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.recoverId();
    this.getSessions();
  }

  recoverId() {
    this.id = this.activeRouter.snapshot.paramMap.get('id');
  }

  public getSessions(): void {
    this.data.getSession().subscribe(
      (res: ResponseSession) => {
        this.session = res;
        this.filterSession = this.session.value;
      },
      (err: any) => console.log(err)
    );
  }

  deleteSession(id: number) {
    const idConvert = id.toString();
    const question = confirm('deseja realmente deletar a Sessao?');
    if (question == true) {
      this.data
        .deleteSession(idConvert)
        .subscribe((res: ResponseSessionUpdate) => {
          if (res.statusCode === 400) alert(res.value);
          else window.location.reload();
        });
    } else alert('Sessão Mantida');
  }
}
