import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ResponseRooms } from 'src/app/models/Rooms';
import { DataService } from 'src/app/services/data.service';

@Component({
  selector: 'app-rooms',
  templateUrl: './rooms.component.html',
  styleUrls: ['./rooms.component.scss'],
})
export class RoomsComponent implements OnInit {
  rooms: ResponseRooms;

  constructor(private data: DataService) {}

  ngOnInit(): void {
    this.getRooms();
  }

  public getRooms(): void {
    this.data.getRooms().subscribe(
      (res) => {
        this.rooms = res;
      },

      (err: any) => console.log(err)
    );
  }
}
