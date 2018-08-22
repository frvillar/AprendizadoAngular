import { Component, Injector } from '@angular/core';
import { AddProjetoGenerated } from './add-projeto-generated.component';

@Component({
  selector: 'add-projeto',
  templateUrl: './add-projeto.component.html'
})
export class AddProjetoComponent extends AddProjetoGenerated {
  constructor(injector: Injector) {
    super(injector);
  }
}
