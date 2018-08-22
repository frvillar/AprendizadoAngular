import { Component, Injector } from '@angular/core';
import { EditProjetoGenerated } from './edit-projeto-generated.component';

@Component({
  selector: 'edit-projeto',
  templateUrl: './edit-projeto.component.html'
})
export class EditProjetoComponent extends EditProjetoGenerated {
  constructor(injector: Injector) {
    super(injector);
  }
}
