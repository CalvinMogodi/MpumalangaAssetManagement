import { DatePipe } from '@angular/common';
import { Component, ElementRef, Input, OnInit, ViewChild } from '@angular/core';
import { MenuItem, MessageService } from 'primeng/api';
import { first } from 'rxjs/operators';
import { LeasedProperty } from 'src/app/models/leased-property.model';
import { LeasedPropertiesService } from 'src/app/services/leased-property/leased-property.service';
import { SharedService } from 'src/app/services/shared.service';

@Component({
  selector: 'app-lease-management',
  templateUrl: './lease-management.component.html',
  styleUrls: ['./lease-management.component.css'],
  providers: [MessageService,]
})
export class LeaseManagementComponent implements OnInit {
  @Input() leasedProperties: Array<LeasedProperty>;
  @ViewChild('exportLP',{ static: false }) myDiv: ElementRef<HTMLElement>;
  showLMDDialog: boolean = false;
  loading: boolean;
  dataIsLoaded: boolean = false;
  showComfirmaDelete: boolean = false;
  doExport: boolean = false;
  isBusy: boolean;
  errorMsg: string;
  error = '';
  selectedLeasedProperty: LeasedProperty;
  buttonItems: MenuItem[];  
  printItems: MenuItem[];
  items = [
    { icon: 'pi pi-home',url: 'dashboard' },
    { label: 'Lease Management' }];
  cols = [
    { field: 'fileReference', header: 'File Reference' },
    { field: 'district', header: 'District' },
    { field: 'type', header: 'Type' },
    { field: 'propertyCode', header: 'Property Code' },
    { field: 'facilityName', header: 'Facility Name' },
    { field: 'natureofLease', header: 'Nature of Lease' },
    { field: 'startingDate', header: 'Starting Date' },
    { field: 'terminationDate', header: 'Termination Date' }
  ];

  constructor(private leasedPropertiesService: LeasedPropertiesService, private sharedService: SharedService, private messageService: MessageService,) {
    this.selectedLeasedProperty = this.sharedService.initLeasedProperty();
   }

  ngOnInit() {
    this.buttonItems = [
      {
        label: 'View', icon: 'pi pi-eye', command: () =>
          this.viewLeasedProperty()
      }, {
        label: 'Delete', icon: 'pi pi-trash', command: () =>
          this.showComfirmaDeleteProperty()
      }
  ]; 
  this.printItems = [
    {
      label: 'PDF', icon: 'pi pi-file-pdf', command: () =>
        this.exportPdf()
    }, {
      label: 'Excel', icon: 'pi pi-file-excel', command: () =>
        this.exportExcel()
    }
]; 
    this.getLeasedProperties();  
   
  }

  getLeasedProperties() {
    this.leasedPropertiesService.getLeasedProperties().pipe(first()).subscribe(leasedProperties => {
      this.leasedProperties = leasedProperties;    
      this.dataIsLoaded = true;
    });   
  }

  viewLeasedProperty(){
    this.leasedPropertiesService.getLeasedPropertyDetails(this.selectedLeasedProperty).pipe(first()).subscribe(leasedProperty => {
      this.selectedLeasedProperty = leasedProperty;    
      this.showLMDDialog = true;
    });    
  }

  showComfirmaDeleteProperty(){
    this.showComfirmaDelete = true;
  }

  deleteLeasedProperty(){
    const index = this.leasedProperties.indexOf(this.selectedLeasedProperty);
    this.leasedProperties.splice(index, 1);
    this.messageService.add({ severity: 'warn', summary: ' Property', detail: 'Property has been deleted successful.' });
  }

  exportPdf() {
    import("jspdf").then(jsPDF => {
        import("jspdf-autotable").then(x => {
            const doc = new jsPDF.default();
            //doc.autoPrint(this.cols, this.leasedProperties);
            doc.save('Leased Properties.pdf');
        })
    })
}

exportExcel() {
    import("xlsx").then(xlsx => {
        const worksheet = xlsx.utils.json_to_sheet(this.leasedProperties);
        const workbook = { Sheets: { 'data': worksheet }, SheetNames: ['data'] };
        const excelBuffer: any = xlsx.write(workbook, { bookType: 'xlsx', type: 'array' });
        this.saveAsExcelFile(excelBuffer, "products");
    });
}

saveAsExcelFile(buffer: any, fileName: string): void {
  import('file-saver').then(FileSaver => {
      let EXCEL_TYPE = 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet;charset=UTF-8';
      let EXCEL_EXTENSION = '.xlsx';
      const data: Blob = new Blob([buffer], {
          type: EXCEL_TYPE
      });
      FileSaver.saveAs(data, 'Leased Properties' + new Date().getDate() + "-" + new Date().getMonth() + "-" + new Date().getFullYear()  + EXCEL_EXTENSION);
  });
}

  attachSnagList(){

  }

  attachFinalHandoverDocument(){

  }

  selectLeasedProperty(leasedProperty: LeasedProperty){
    this.selectedLeasedProperty = leasedProperty;
  }
  exportLeasedProperty(){
    this.leasedPropertiesService.getLeasedPropertyDetails(this.selectedLeasedProperty).pipe(first()).subscribe(leasedProperty => {
      this.selectedLeasedProperty = leasedProperty;    
      this.doExport = true;
      let el: HTMLElement = this.myDiv.nativeElement;
      el.click();
    });     
  }

}
