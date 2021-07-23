import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Price } from '../models/price';
import { StoreService } from '../_services/store.service';

@Component({
  selector: 'app-add-form',
  templateUrl: './add-form.component.html',
  styleUrls: ['./add-form.component.sass']
})
export class AddFormComponent implements OnInit {
  @Output() cancelRegister = new EventEmitter();
  AddForm: FormGroup;
  priceControl = new FormControl();
  Types = [
    { value: 'laptops', viewValue: 'laptops' },
    { value: 'phones', viewValue: 'phones' },
    { value: 'tablets', viewValue: 'tablets' }
  ];

  constructor(private formBuilder: FormBuilder, private storeService: StoreService,private  router: Router) { }

  ngOnInit(): void {
    this.initializeForm();
  }
  initializeForm() {
    this.AddForm = this.formBuilder.group({
      item: ['', Validators.required],
      productType: ['', Validators.required],
      numItems: ['', Validators.required]
    });
  }

  submit() {
    this.storeService.AddToInventory(this.AddForm.value).subscribe(() => {  
      this.router.navigateByUrl('/AddPrice');
    }, error => {
      console.log(error)
    });

  }

  cancel() {
    this.cancelRegister.emit(false);
  }
}
