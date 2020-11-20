import { Component } from '@angular/core';



@Component({
  selector: 'app-theme',
  templateUrl: './theme.component.html',
})
export class themeComponent {
  public theme : Theme

  constructor() {
    console.log(this.theme);
  }
}
interface Theme {
  libelle: string;

}
