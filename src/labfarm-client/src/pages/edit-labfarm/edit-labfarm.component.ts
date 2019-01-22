import { Component, OnInit, Input, Inject } from '@angular/core';
import { LabFarm } from 'src/models/LabFarm';
import { LabfarmService } from 'src/providers/labfarm/labfarm.service';
import { ActivatedRoute, Router } from '@angular/router';
import { FormGroup, FormControl, Validators } from '@angular/forms';

import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';

@Component({
  selector: 'app-edit-labfarm',
  templateUrl: './edit-labfarm.component.html',
  styleUrls: ['./edit-labfarm.component.scss']
})
export class EditLabfarmComponent implements OnInit {

  private labfarm: LabFarm;
  private serverError: boolean = false;

  private labfarmForm: FormGroup;
  private inputError: boolean = false;

  private labfarmId: number;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private labfarmService: LabfarmService,
    private dialog: MatDialog
  ) {
    this.labfarmId = parseInt(this.route.snapshot.paramMap.get("id"));
    this.labfarmService.getLabFarmById(this.labfarmId).subscribe(data => {
      this.labfarm = data;
    }, failed => {
      console.log(failed);
      this.serverError = true;
    })
  }

  ngOnInit() {
  }

  private checkLabFarm() {
    this.inputError = false;

    this.labfarmForm = new FormGroup({
      'name': new FormControl(this.labfarm.name, [
        Validators.required,
        Validators.minLength(4)
      ]),
      'plantSpecies': new FormControl(this.labfarm.plantSpecies, [
        Validators.required,
        Validators.minLength(4)
      ]),
      'dustLow': new FormControl(this.labfarm.dustLevelLow, Validators.required),
      'dustHigh': new FormControl(this.labfarm.dustLevelHigh, Validators.required),
      'lightLow': new FormControl(this.labfarm.lightLevelLow, Validators.required),
      'lightHigh': new FormControl(this.labfarm.lightLevelHigh, Validators.required),
      'tempLow': new FormControl(this.labfarm.temperatureLevelLow, Validators.required),
      'tempHigh': new FormControl(this.labfarm.temperatureLevelHigh, Validators.required),
      'condLow': new FormControl(this.labfarm.conductivityLevelLow, Validators.required),
      'condHigh': new FormControl(this.labfarm.conductivityLevelHigh, Validators.required),
      'waterLow': new FormControl(this.labfarm.minimumReservoirLevel, Validators.required),
      'waterHigh': new FormControl(this.labfarm.maximumReservoirLevel, Validators.required)
    });


    if (this.labfarmForm.valid)
      this.saveLabFarm(this.labfarm, this.labfarmId);
    else
      this.invalidFormInput();
  }

  private saveLabFarm(lf: LabFarm, labfarmId: number) {
    console.log("New labfarm input is valid, sending it to the API");

    this.labfarmService.updateLabFarm(lf, labfarmId).subscribe(success => {
      console.log(success);
      this.router.navigate(['/home']);
    }, error => {
      console.log(error);
    });

  }

  private invalidFormInput() {
    console.log("New labfarm input is invalid");
    this.inputError = true;
  }

  private deleteLabFarm(): void {
    const dialogRef = this.dialog.open(DeleteDialog, {
      width: '500px',
      data: { labfarmId: this.labfarmId }
    });

    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed');

    });
  }

}

interface DialogData {
  labfarmId: number;
}

@Component({
  selector: 'delete-dialog',
  templateUrl: 'delete-dialog.html',
})
export class DeleteDialog {

  private savingLabfarm: boolean = false;
  private labfarmId: number;

  constructor(private router: Router, private labfarmService: LabfarmService, public dialogRef: MatDialogRef<DeleteDialog>, @Inject(MAT_DIALOG_DATA) private data: DialogData) {

  } 

  private onNoClick(): void {
    this.dialogRef.close();
  }

  private delete() {
    console.log("Deleting labfarm with ID: "+ this.data.labfarmId);
    this.savingLabfarm = true;
    this.labfarmService.deleteLabFarm(this.labfarmId).subscribe(data => {
      this.router.navigate(['/home']);
      this.dialogRef.close();
    }, error => {
      console.log("Could not delete labfarm");
    })
  }

  private cancel() {
    this.dialogRef.close();
  }

}
