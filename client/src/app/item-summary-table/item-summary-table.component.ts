import { AfterViewInit, Component, EventEmitter, OnInit, Output, ViewChild } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTable } from '@angular/material/table';
import { Router } from '@angular/router';
import { Item } from '../models/ItemSummary';
import { Product } from '../models/product';
import { StoreService } from '../_services/store.service';


@Component({
  selector: 'app-item-summary-table',
  templateUrl: './item-summary-table.component.html',
  styleUrls: ['./item-summary-table.component.css']
})

//was going to use a table but then I changed to a form for this component hance the name ItemSummaryTableComponent
export class ItemSummaryTableComponent implements OnInit {
  @Output() cancelRegister = new EventEmitter();
  ItemForm: FormGroup;
  Item: Item;
  products: Product;

  constructor(private formBuilder: FormBuilder, private storeService: StoreService, private router: Router) 
  {
  
  }


  ngOnInit(): void {
    this.initializeForm();
    this.storeService.SummaryOfAll().subscribe(summary => {
      this.products = summary;
    });
  }

  initializeForm() {

    this.ItemForm = this.formBuilder.group({
      productItemType: ['', Validators.required]
    });
  }

  submit() {
    
    this.storeService.SummaryOfItem(this.ItemForm.value).subscribe(s => {
      this.Item = s;
      console.log(this.Item);
    }, error => {
      console.log(error)
    });
  }
}