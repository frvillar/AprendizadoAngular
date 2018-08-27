import { Component, Injector, OnChanges, SimpleChange, ChangeDetectorRef, SimpleChanges } from '@angular/core';
import { RelatorioGenerated } from './relatorio-generated.component';
import { DialogService, DIALOG_PARAMETERS, DialogRef } from '@radzen/angular/dist/dialog';
import { ActivatedRoute, Router } from '@angular/router';
import { NotificationService } from '@radzen/angular/dist/notification';
import { Location } from '@angular/common';

@Component({
  selector: 'relatorio',
  templateUrl: './relatorio.component.html'
})
export class RelatorioComponent extends RelatorioGenerated {
  constructor(injector: Injector, private rota: Router) {
      super(injector);
      this.rota.routeReuseStrategy.shouldReuseRoute = () => false;
  }

    public relato = 'cproj/extratocliente' 

    ngOnInit() {
        super.ngOnInit();
        this.route.params.subscribe(routeParams => {
            if (routeParams['relNome'] != null) {
                this.relato = 'cproj/' + routeParams['relNome'];
            }
        });
    }

    
}
