# Find the k Nearest Neighbors
import pandas as pd
import numpy as np
import pyodbc
import uuid
conn = pyodbc.connect('Driver={SQL Server};'
                      'Server=EVELIO;'
                      'Database=Beadev;'
                      'Trusted_Connection=yes;')

ProgrammingLanguagesDataSet = pd.read_csv(r'C:\Users\jobst\Desktop\PL.csv')

ProgrammingLanguagesDataSet.columns = [
    "ProgrammingLanguageID",
    "Month",
    "SalaryRate",
    "JobOffers",
]

plang = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10]
month = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12]

ProgrammingLanguagesDataSet = ProgrammingLanguagesDataSet.drop(
    "SalaryRate", axis=1)

X = ProgrammingLanguagesDataSet.drop("JobOffers", axis=1)
X = X.values
y = ProgrammingLanguagesDataSet["JobOffers"]
y = y.values


for i in plang:
    for j in month:
        new_data_point = np.array([
            i,
            j
        ])
        distances = np.linalg.norm(X - new_data_point, axis=1)
        k = 3
        nearest_neighbor_ids = distances.argsort()[:k]
        nearest_neighbor_ids

        nearest_neighbor_joboffers = y[nearest_neighbor_ids]
        nearest_neighbor_joboffers
        prediction = nearest_neighbor_joboffers.mean()
        print(prediction)
        cursor = conn.cursor()

        cursor.execute("INSERT INTO [Statistics] (Id,TotalOffers,MonthID,ProgrammLangID) values(?,?,?,?)",
                       str(uuid.uuid4()),prediction,j,i)

        conn.commit()

