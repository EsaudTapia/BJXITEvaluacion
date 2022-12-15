export class User {   
    userId : number=0;
    name :string;
    lastName:string;
    phoneNumber :string;
    direction :string;
    postalCode :string;    
    email :string;
    password :string;
    roleId : number=0;

    constructor(
        userId : number=0,
        name :string="",
        lastName:string="",
        phoneNumber :string="",
        direction :string="",
        postalCode :string="",
        email :string="",
        password :string="",
        roleId : number=0
    ) {}
    
}  

