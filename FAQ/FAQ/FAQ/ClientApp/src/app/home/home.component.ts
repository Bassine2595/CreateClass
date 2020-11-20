
import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  public Themes: Theme[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Theme[]>(baseUrl + 'theme').subscribe(result => {
      this.Themes = result;
    }, error => console.error(error));
  }
}
interface Theme {
  libelle: string;

}

