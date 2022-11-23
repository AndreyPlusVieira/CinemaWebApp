import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { RequestSession } from 'src/app/models/Session';
import { DataService } from 'src/app/services/data.service';

@Component({
  selector: 'app-update-session',
  templateUrl: './update-session.component.html',
  styleUrls: ['./update-session.component.scss'],
})
export class UpdateSessionComponent implements OnInit {
  id: any;
  date: Date = new Date();
  form: FormGroup;
  request: RequestSession = {
    id: 0,
    startTime: this.date,
    endTIme: this.date,
    entryValue: 0,
    animationType: '2D',
    audioType: 'Original',
    roomsId: 1,
    movieId: 1,
  };

  constructor(
    private fb: FormBuilder,
    private data: DataService,
    private route: Router,
    private router: ActivatedRoute
  ) {}

  ngOnInit(): void {
    this.Validation();
    this.findId();
  }

  findId() {
    this.id = this.router.snapshot.paramMap.get('id');

    this.data.getSessionById(this.id).subscribe((res) => {
      this.request = {
        id: res.value.id,
        startTime: this.date,
        endTIme: res.value.endTIme,
        entryValue: res.value.entryValue,
        animationType: res.value.animationType,
        audioType: res.value.audioType,
        roomsId: res.value.roomsId,
        movieId: res.value.movieId,
      };
    });
  }

  public Validation(): void {
    this.form = this.fb.group({
      StartTime: ['', [Validators.required]],
      EntryValue: ['', [Validators.required]],
      RoomId: ['', [Validators.required]],
      MovieId: ['', [Validators.required]],
      animation: ['', [Validators.required]],
      Audio: ['', [Validators.required]],
    });
  }

  update() {
    this.data.updateSession(this.id, this.request).subscribe((res) => {
      if (res.statusCode === 400) alert(res.value);
      else alert(`Atualizado`);
    });
  }
}
