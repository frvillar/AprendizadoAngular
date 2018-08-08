import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { NoopAnimationsModule } from '@angular/platform-browser/animations';

import { DataTableModule, DialogModule, PaginatorModule, PanelModule, TooltipModule } from 'primeng/primeng';
import { AngularODataModule } from 'angular-OData-ES5/angularOData.module';


import { DemoComponent } from './demo.component';
import { EmployeeGridODataComponent } from './employeeGrid/employeeGridOData.component';

@NgModule({
    declarations: [DemoComponent, EmployeeGridODataComponent],
    exports: [PanelModule, NoopAnimationsModule],
    // tslint:disable-next-line:max-line-length
  imports: [BrowserModule, HttpClientModule, DataTableModule, TooltipModule, PaginatorModule, DialogModule, PanelModule, NoopAnimationsModule, AngularODataModule.forRoot()],
    bootstrap: [DemoComponent]
})
export class DemoModule { }
