import { Component } from '@angular/core';

@Component({
  selector: 'app-frame-page',
  template: `<app-header></app-header><router-outlet></router-outlet
    ><app-footer></app-footer>`,
})
export class FramePageComponent {}
