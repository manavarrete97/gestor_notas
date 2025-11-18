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
 public class GetEstudianteManagerTests
 {
 private Mock<IPostgresConnection> _postgresConnectionMock;
 private Mock<IGetEstudianteDAO> _getEstudianteDAOMock;
 private GetEstudianteManager _getEstudianteManager;
 private NpgsqlConnection _realConnection;

 [SetUp]
 public void Setup()
 {
 _postgresConnectionMock = new Mock<IPostgresConnection>();
 _getEstudianteDAOMock = new Mock<IGetEstudianteDAO>();
 _getEstudianteManager = new GetEstudianteManager(_postgresConnectionMock.Object, _getEstudianteDAOMock.Object);
 _realConnection = new NpgsqlConnection(); // Replace with a valid connection string for testing
 }

 [TearDown]
 public void TearDown()
 {
 _realConnection.Dispose();
 }

 [Test]
 public async Task GetEstudianteByIdAsync_ShouldReturnEstudiante_WhenExists()
 {
 // Arrange
 var estudianteDTO = new EstudianteDTO { Id =1, Nombre = "Juan Pérez" };
 _postgresConnectionMock.Setup(p => p.GetConnection()).Returns(_realConnection);
 _getEstudianteDAOMock.Setup(p => p.GetEstudianteByIdAsync(It.IsAny<NpgsqlConnection>(),1)).ReturnsAsync(estudianteDTO);

 // Act
 var result = await _getEstudianteManager.GetEstudianteByIdAsync(1);

 // Assert
 Assert.That(result, Is.Not.Null);
 Assert.That(result.Id, Is.EqualTo(estudianteDTO.Id));
 Assert.That(result.Nombre, Is.EqualTo(estudianteDTO.Nombre));
 }

 [Test]
 public async Task GetEstudianteByIdAsync_ShouldReturnNull_WhenNotExists()
 {
 // Arrange
 _postgresConnectionMock.Setup(p => p.GetConnection()).Returns(_realConnection);
 _getEstudianteDAOMock.Setup(p => p.GetEstudianteByIdAsync(It.IsAny<NpgsqlConnection>(),1)).ReturnsAsync((EstudianteDTO)null);

 // Act
 var result = await _getEstudianteManager.GetEstudianteByIdAsync(1);

 // Assert
 Assert.That(result, Is.Null);
 }

 [Test]
 public async Task GetAllEstudiantesAsync_ShouldReturnListOfEstudiantes()
 {
 // Arrange
 var estudiantes = new List<EstudianteDTO>
 {
 new EstudianteDTO { Id =1, Nombre = "Juan Pérez" },
 new EstudianteDTO { Id =2, Nombre = "Ana Gómez" }
 };
 _postgresConnectionMock.Setup(p => p.GetConnection()).Returns(_realConnection);
 _getEstudianteDAOMock.Setup(p => p.GetAllEstudiantesAsync(It.IsAny<NpgsqlConnection>())).ReturnsAsync(estudiantes);

 // Act
 var result = await _getEstudianteManager.GetAllEstudiantesAsync();

 // Assert
 Assert.That(result, Is.Not.Null);
 Assert.That(result.Count, Is.EqualTo(2));
 }
 }
}