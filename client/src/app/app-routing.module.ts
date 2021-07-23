import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddFormComponent } from './add-form/add-form.component';
import { AddPriceComponent } from './add-price/add-price.component';
import { ItemSummaryTableComponent } from './item-summary-table/item-summary-table.component';
import { SellFormComponent } from './sell-form/sell-form.component';
import { SummaryTableComponent } from './summary-table/summary-table.component';

const routes: Routes = [
  { path: '', component: AddFormComponent },
  { path: 'Add', component: AddFormComponent },
  { path: 'AddPrice', component: AddPriceComponent },
  { path: 'Summary', component: SummaryTableComponent },
  { path: 'ItemSummary', component: ItemSummaryTableComponent },
  { path: 'Sell', component: SellFormComponent }


];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
