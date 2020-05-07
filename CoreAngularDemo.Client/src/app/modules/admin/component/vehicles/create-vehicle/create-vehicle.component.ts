import { Component, OnInit, ElementRef, EventEmitter, ViewChild, Output } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormControl } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { Vehicle } from 'src/app/modules/shared/models/vehicle';
import { VehicleType } from 'src/app/modules/shared/models/vehicleType';
import { VehicleTypeService } from 'src/app/modules/shared/services/vehicle-type.service';
import { VehicleService } from 'src/app/modules/shared/services/vehicle.service';
import { NUM_FIELD_ERRORS, LET_NUM_FIELD_ERRORS } from 'src/app/custom-errors';
import { Location } from 'src/app/modules/shared/models/location';
import { LocationService } from 'src/app/modules/shared/services/location.service';

@Component({
  selector: 'app-create-vehicle',
  templateUrl: './create-vehicle.component.html',
  styleUrls: ['./create-vehicle.component.scss']
})
export class CreateVehicleComponent implements OnInit {
  constructor(
    private serviceVehicleType: VehicleTypeService,
    private serviceVehicle: VehicleService,
    private serviceLocation: LocationService,
    private formBuilder: FormBuilder,
    private toast: ToastrService
  ) { }

  get vehicleTypeName(): string[] {
    return this.vehicleTypeList.map(t => t.name);
  }
  @ViewChild('close') closeDiv: ElementRef;
  @Output() createVehicle = new EventEmitter<Vehicle>();
  vehicleForm: FormGroup;
  vehicleTypeList: VehicleType[] = [];
  locationList: Location[] = [];

  CustomNumErrorMessages = NUM_FIELD_ERRORS;
  CustomLetNumErrorMessages = LET_NUM_FIELD_ERRORS;

  ngOnInit() {
    $('#createVehicle').on('hidden.bs.modal', function () {
      $(this)
        .find('form')
        .trigger('reset');
    });
    this.vehicleForm = this.formBuilder.group({
      vehicleType: new FormControl('', Validators.required),
      vincode: new FormControl('', Validators.compose([Validators.required, Validators.minLength(17), Validators.maxLength(17), Validators.pattern("^[A-Za-z0-9]+$")])),
      inventoryId: new FormControl('', Validators.pattern('^[0-9]+$')),
      regNum: new FormControl('', Validators.compose([Validators.required, Validators.maxLength(15), Validators.pattern("^[A-Z0-9a-zА-Яа-яїієЇІЯЄ]+$")])),
      brand: new FormControl('', Validators.compose([Validators.required, Validators.maxLength(30), Validators.pattern("^[A-Z0-9a-zА-Яа-яїієЇІЯЄ]+$")])),
      model: new FormControl('', Validators.compose([Validators.minLength(1), Validators.maxLength(30)])),
      commissioningDate: new FormControl('', Validators.required),
      warrantyEndDate: new FormControl('', Validators.required),
      location: new FormControl('')
    });
    this.serviceVehicleType.getEntities().subscribe(data => (this.vehicleTypeList = data.sort((a, b) => a.name.localeCompare(b.name))));
    this.serviceLocation.getEntities().subscribe(data => (this.locationList = data));
  }

  clickSubmit() {
    if (this.vehicleForm.invalid) {
      return;
    }

    const form = this.vehicleForm.value;
    const vehicle: Vehicle = new Vehicle({
      id: 0,
      vehicleType: this.vehicleTypeList[this.vehicleTypeName.findIndex(t => t === form.vehicleType)],
      vincode: form.vincode as string,
      inventoryId: form.inventoryId as string,
      regNum: form.regNum as string,
      brand: form.brand as string,
      model: form.model as string,
      commissioningDate: form.commissioningDate as Date,
      warrantyEndDate: form.warrantyEndDate as Date,
      location: this.locationList.find(t => t.name === form.location)
    });
    this.serviceVehicle
      .addEntity(vehicle)
      .subscribe(
        newVehicle => {
          this.createVehicle.next(newVehicle);
        },
        _ => this.toast.error('Транспорт з таким vin-кодом або інвентарним номером вже існує'),
        () => {
          this.closeDiv.nativeElement.click();
          this.toast.success('Транспорт створено');
        }
      );
  }
}
