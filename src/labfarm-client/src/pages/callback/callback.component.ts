import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from 'src/providers/authentication/authentication.service';

@Component({
  selector: 'app-callback',
  templateUrl: './callback.component.html',
  styleUrls: ['./callback.component.scss']
})
export class CallbackComponent implements OnInit {

  constructor(private authService: AuthenticationService) { }

  ngOnInit() {
      
  }

}
