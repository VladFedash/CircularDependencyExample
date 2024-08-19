# CircularDependencyExample

Structure for circular dependency occurrence:


<img width="458" alt="image" src="https://github.com/user-attachments/assets/19cc860f-d004-4bcd-96ce-c939530cc7c7">




Code view:



<img width="584" alt="image" src="https://github.com/user-attachments/assets/e11b2a85-5d8e-4e0b-8204-0dc5e173c116">


You can see result difference here between Newtonsoft.Json and System.Text.Json:



<img width="1164" alt="image" src="https://github.com/user-attachments/assets/051e6fdc-aeea-4d82-b4a7-41479b605be7">






Circular dependency can be resolved with these two ReferenceHandler values: 



<img width="512" alt="image" src="https://github.com/user-attachments/assets/fb278f94-550c-4f59-8a76-e158fa5491d6">




But for the Preserve option result will be with this view: 



<img width="1201" alt="image" src="https://github.com/user-attachments/assets/b01c7890-94b7-4de4-b848-e8e312874ee6">

 
