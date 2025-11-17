using gestor_notas.DTO;
using gestor_notas.Manager;
using gestor_notas.DAO.Interface;
using gestor_notas.Common.Interface;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;
using Npgsql;

namespace gestor_notas_test
{
 [TestFixture]
 public class GetProfesorManagerTests
 {
 private Mock<IPostgresConnection> _postgresConnectionMock;
 private Mock<IGetProfesorDAO> _getProfesorDAOMock;
 private GetProfesorManager _getProfesorManager;
 private NpgsqlConnection _realConnection;

 [SetUp]
 public void Setup()
 {
 _postgresConnectionMock = new Mock<IPostgresConnection>();
 _getProfesorDAOMock = new Mock<IGetProfesorDAO>();
 _getProfesorManager = new GetProfesorManager(_postgresConnectionMock.Object, _getProfesorDAOMock.Object);
 _realConnection = new NpgsqlConnection(); // Replace with a valid connection string for testing
 }

 [TearDown]
 public void TearDown()
 {
 _realConnection.Dispose();
 }

 [Test]
 public async Task GetProfesorByIdAsync_ShouldReturnProfesor_WhenExists()
 {
 // Arrange
 var profesorDTO = new ProfesorDTO { Id =1, Nombre = "Juan Pérez" };
 _postgresConnectionMock.Setup(p => p.GetConnection()).Returns(_realConnection);
 _getProfesorDAOMock.Setup(p => p.GetProfesorByIdAsync(It.IsAny<NpgsqlConnection>(),1)).ReturnsAsync(profesorDTO);

 // Act
 var result = await _getProfesorManager.GetProfesorByIdAsync(1);

 // Assert
 Assert.That(result, Is.Not.Null);
 Assert.That(result.Id, Is.EqualTo(profesorDTO.Id));
 Assert.That(result.Nombre, Is.EqualTo(profesorDTO.Nombre));
 }

 [Test]
 public async Task GetProfesorByIdAsync_ShouldReturnNull_WhenNotExists()
 {
 // Arrange
 _postgresConnectionMock.Setup(p => p.GetConnection()).Returns(_realConnection);
 _getProfesorDAOMock.Setup(p => p.GetProfesorByIdAsync(It.IsAny<NpgsqlConnection>(),1)).ReturnsAsync((ProfesorDTO)null);

 // Act
 var result = await _getProfesorManager.GetProfesorByIdAsync(1);

 // Assert
 Assert.That(result, Is.Null);
 }

 [Test]
 public async Task GetAllProfesoresAsync_ShouldReturnListOfProfesores()
 {
 // Arrange
 var profesores = new List<ProfesorDTO>
 {
 new ProfesorDTO { Id =1, Nombre = "Juan Pérez" },
 new ProfesorDTO { Id =2, Nombre = "Ana Gómez" }
 };
 _postgresConnectionMock.Setup(p => p.GetConnection()).Returns(_realConnection);
 _getProfesorDAOMock.Setup(p => p.GetAllProfesoresAsync(It.IsAny<NpgsqlConnection>())).ReturnsAsync(profesores);

 // Act
 var result = await _getProfesorManager.GetAllProfesoresAsync();

 // Assert
 Assert.That(result, Is.Not.Null);
 Assert.That(result.Count, Is.EqualTo(2));
 }
 }
}