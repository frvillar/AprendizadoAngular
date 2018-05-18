import { Component } from '@angular/core';
import { clearModulesForTest } from '@angular/core/src/linker/ng_module_factory_loader';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  userName = 'Villar'

  clearUser(){
    this.userName = '';
  }
}

