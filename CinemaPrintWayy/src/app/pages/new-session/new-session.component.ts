import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { RequestSession } from 'src/app/models/Session';
import { DataService } from 'src/app/services/data.service';

@Component({
  selector: 'app-new-session',
  templateUrl: './new-session.component.html',
  styleUrls: ['./new-session.component.scss'],
})
export class NewSessionComponent implements OnInit {
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

  get f(): any {
    return this.form.controls;
  }

  constructor(
    private cd: ChangeDetectorRef,
    private fb: FormBuilder,
    private data: DataService,
    private route: Router
  ) {}

  ngOnInit(): void {
    this.Validation();
  }
  ngAfterViewChecked() {
    this.cd.detectChanges();
  }

  save() {
    console.log(this.request);

    this.data.createSession(this.request).subscribe((res) => {
      if (res.statusCode === 400) alert(res.value);
      else alert(`Criado com Sucesso`);
    });
    this.route.navigate(['/sessions']).then((nav) => {
      window.location.reload();
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
}
