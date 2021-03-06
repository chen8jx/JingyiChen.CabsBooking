export interface BookingDetail{
    email:string,
    bookingDate?:Date,
    bookingTime: string,
    pickupAddress: string, 
    landmark:string,
    pickupDate?:Date,
    pickupTime:string,
    contactNo:string,
    status:string,
    comp_Time:string,
    charge?:number,
    feedback:string,
    places:[];
}