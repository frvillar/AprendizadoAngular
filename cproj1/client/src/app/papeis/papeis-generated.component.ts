/*
  This file is automatically generated. Any changes will be overwritten.
  Modify papeis.component.ts instead.
*/
import { ChangeDetectorRef, ViewChild, AfterViewInit, Injector, OnInit, OnDestroy } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';
import { Subscription } from 'rxjs';

import { DialogService, DIALOG_PARAMETERS, DialogRef } from '@radzen/angular/dist/dialog';
import { NotificationService } from '@radzen/angular/dist/notification';
import { ContentComponent } from '@radzen/angular/dist/content';
import { HeadingComponent } from '@radzen/angular/dist/heading';
import { GridComponent } from '@radzen/angular/dist/grid';
import { AddPapeiComponent } from '../add-papei/add-papei.component';
import { EditPapeiComponent } from '../edit-papei/edit-papei.component';

import { CprojdsService } from '../cprojds.service';

export class PapeisGenerated implements AfterViewInit, OnInit, OnDestroy {
  // Components
  @ViewChild('content1') content1: ContentComponent;
  @ViewChild('pageTitle') pageTitle: HeadingComponent;
  @ViewChild('grid0') grid0: GridComponent;

  router: Router;

  cd: ChangeDetectorRef;

  route: ActivatedRoute;

  notificationService: NotificationService;

  dialogService: DialogService;

  dialogRef: DialogRef;

  _location: Location;

  _subscription: Subscription;

  cprojds: CprojdsService;

  getPapeisResult: any;

  getPapeisCount: any;

  parameters: any;

  constructor(private injector: Injector) {
  }

  ngOnInit() {
    this.notificationService = this.injector.get(NotificationService);

    this.dialogService = this.injector.get(DialogService);

    this.dialogRef = this.injector.get(DialogRef, null);

    this.router = this.injector.get(Router);

    this.cd = this.injector.get(ChangeDetectorRef);

    this._location = this.injector.get(Location);

    this.route = this.injector.get(ActivatedRoute);

    this.cprojds = this.injector.get(CprojdsService);
  }

  ngAfterViewInit() {
    this._subscription = this.route.params.subscribe(parameters => {
      if (this.dialogRef) {
        this.parameters = this.injector.get(DIALOG_PARAMETERS);
      } else {
        this.parameters = parameters;
      }
      this.load();
      this.cd.detectChanges();
    });
  }

  ngOnDestroy() {
    this._subscription.unsubscribe();
  }


  load() {
    this.cprojds.getPapeis(null, this.grid0.allowPaging ? this.grid0.pageSize : null, this.grid0.allowPaging ? 0 : null, null, this.grid0.allowPaging, null, null, null)
    .subscribe((result: any) => {
      this.getPapeisResult = result.value;

      this.getPapeisCount = this.grid0.allowPaging ? result['@odata.count'] : result.value.length;
    }, (result: any) => {

    });
  }

  grid0LoadData(event: any) {
    this.cprojds.getPapeis(`${event.filter}`, event.top, event.skip, `${event.orderby}`, event.top != null && event.skip != null, ``, null, null)
    .subscribe((result: any) => {
      this.getPapeisResult = result.value;

      this.getPapeisCount = event.top != null && event.skip != null ? result['@odata.count'] : result.value.length;
    }, (result: any) => {

    });
  }

  grid0Delete(event: any) {
    this.cprojds.deletePapei(event.Papel)
    .subscribe((result: any) => {
      this.notificationService.notify({ severity: "success", summary: `Success`, detail: `Papei deleted!` });
    }, (result: any) => {
      this.notificationService.notify({ severity: "error", summary: `Error`, detail: `Unable to delete Papei` });
    });
  }

  grid0Add(event: any) {
    this.dialogService.open(AddPapeiComponent, { parameters: {}, title: 'Add Papei' });
  }

  grid0RowSelect(event: any) {
    this.dialogService.open(EditPapeiComponent, { parameters: {Papel: event.Papel}, title: 'Edit Papei' });
  }
}
